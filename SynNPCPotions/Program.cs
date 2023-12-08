using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;
using StringCompareSettings;

namespace SynNPCPotions
{
    public class Program
    {
        static Lazy<PatcherSettings> Settings = null!;
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetAutogeneratedSettings("PatcherSettings", "settings.json", out Settings)
                .SetTypicalOpen(GameRelease.SkyrimSE, "SynNPCPotions.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            var settings = Settings.Value;

            if (settings.CustomPacks.Count == 0)
            {
                Console.WriteLine("Nothing to add. Finished..");
            }

            int patchedNpcCount = 0;
            foreach (var npcGetter in state.LoadOrder.PriorityOrder.Npc().WinningOverrides())
            {
                // skip invalid
                CheckRemoveNPCPotionsScript(state, npcGetter);

                if (!IsValidNpc(npcGetter, state, settings)) continue;

                patchedNpcCount++;

                var npcEdId = npcGetter.EditorID;
                var npcClass = npcGetter.Class == null || npcGetter.Class.IsNull || npcGetter.Class.FormKeyNullable == null ? null :  state.LinkCache.Resolve<IClassGetter>(npcGetter.Class.FormKey);
                if (npcClass == null) continue;

                var npcClassEdId = npcClass.EditorID;
                var itemsToAdd = new List<CustomItem>();
                foreach (var data in settings.CustomPacks)
                {
                    if (npcEdId.HasAnyFromList(data.NpcEdIdExclude)) continue;
                    if (npcClassEdId.HasAnyFromList(data.NpcClassEdIdExclude)) continue;
                    if (!npcEdId.HasAnyFromList(data.NpcEdIdInclude) 
                        && !npcClassEdId.HasAnyFromList(data.NpcClassEdIdInclude)) continue;

                    itemsToAdd.AddRange(data.ItemsToAdd);
                }

                if (itemsToAdd.Count == 0) continue;

                // add potions list
                AddPotions(npcGetter, itemsToAdd, state);
            }

            Console.WriteLine($"Patched {patchedNpcCount} npc records.");
        }

        private static void AddPotions(INpcGetter npcGetter, List<CustomItem> itemsToAdd, IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            var npcEdit = state.PatchMod.Npcs.GetOrAddAsOverride(npcGetter);
            npcEdit.Items ??= new Noggog.ExtendedList<ContainerEntry>();

            foreach(var items in itemsToAdd)
            {
                var lList = state.PatchMod.LeveledItems.GetOrAddAsOverride();

                var level = items.LLILevel;
                var flags = items.LLIFlags;
                foreach (var item in items.Items)
                {
                    var entrie = new ContainerEntry { Item = new ContainerItem() };
                    entrie.Item.Item.FormKey = item.Items;
                    entrie.Item.Count = 1;
                }
            }

            npcEdit.Items.Add(entrie);
        }

        private static FormKey TryGetLLI(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            // search custom packs
            foreach (var customPack in customPacks)
            {
                if (!npcGetter.EditorID.HasAnyFromList(customPack.NpcEdIdInclude)) continue;

                return SetLLI(state, customPack.ItemsToAdd);
            }
            return FormKey.Null;
        }

        private static void CheckRemoveNPCPotionsScript(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, INpcGetter npcGetter)
        {
            ScriptEntry? npcPotionsEntry;
            if (npcGetter.VirtualMachineAdapter != null && (npcPotionsEntry = (ScriptEntry?)npcGetter.VirtualMachineAdapter.Scripts.FirstOrDefault(s => s != null && s.Name == "NPCPotions", null)) != null)
            {
                var npcRemoveNPCPotionsScript = state.PatchMod.Npcs.GetOrAddAsOverride(npcGetter);
                npcRemoveNPCPotionsScript.VirtualMachineAdapter!.Scripts.Remove(npcPotionsEntry);
            }
        }

        private static FormKey SetLLI(IPatcherState<ISkyrimMod, ISkyrimModGetter> state, IEnumerable<CustomItem> itemsData)
        {
            var itemLLists = new List<IFormLink<IItemGetter>>();

            foreach (var itemData in itemsData)
            {
                // create leveled itema list
                var lVLISub = state.PatchMod.LeveledItems.AddNew(); // Sublist including item records which will be added with selected chance
                lVLISub.EditorID = "LItemGeneratedNPCPotionsSub" + "I" + itemData.Items.First().FormKey.ToString().Remove(6, 1) + "C" + itemData.LLICount + "P" + itemData.LLIChance; // "LItemGeneratedNPCPotionsSub";
                lVLISub.ChanceNone = (byte)(100 - itemData.LLIChance); // here chance to add, 10% if 90
                foreach (var flagData in itemData.LLIFlags) lVLISub.Flags |= flagData.Flag;
                lVLISub.Entries = new Noggog.ExtendedList<LeveledItemEntry>();
                // fix count chance
                if (itemData.LLILevel <= 0) itemData.LLILevel = 1;
                if (itemData.LLICount <= 0) itemData.LLICount = 1;

                // here add specific pack of leveled entries inside, maybe set in settings
                // entries can be many, from some lists from patcher settings
                short level = (short)itemData.LLILevel;
                short count = (short)itemData.LLICount;
                foreach (var item in itemData.Items)
                {
                    var LVLIEntrie = new LeveledItemEntry
                    {
                        Data = new LeveledItemEntryData
                        {
                            Level = level,
                            Count = count,
                            Reference = item
                        }
                    };
                    lVLISub.Entries.Add(LVLIEntrie);
                }
                itemLLists.Add(lVLISub.ToLink());
            }


            var lVLIToAdd = state.PatchMod.LeveledItems.AddNew(); // main leveled items list, which will be added to valid npcs
            lVLIToAdd.EditorID = "LItemGeneratedNPCPotions";
            lVLIToAdd.ChanceNone = 0; // 100%
            lVLIToAdd.Flags |= LeveledItem.Flag.UseAll; // all record will be calculated
            lVLIToAdd.Flags |= LeveledItem.Flag.CalculateForEachItemInCount; // all record will be calculated
            lVLIToAdd.Entries = new Noggog.ExtendedList<LeveledItemEntry>();

            foreach (var lliLink in itemLLists)
            {
                var lVLIToAddEntrie = new LeveledItemEntry
                {
                    Data = new LeveledItemEntryData
                    {
                        Level = 1,
                        Count = 1,
                        Reference = lliLink // set sublist with potions
                    }
                };

                lVLIToAdd.Entries.Add(lVLIToAddEntrie);
            }

            return lVLIToAdd.FormKey;
        }

        private static bool isCheckPlayer = true;
        static readonly FormKey playerFormKey = FormKey.Factory("000007:Skyrim.esm");
        private static bool IsValidNpc(INpcGetter npcGetter, IPatcherState<ISkyrimMod, ISkyrimModGetter> state, PatcherSettings settings)
        {
            if (npcGetter.IsDeleted) return false;
            if (isCheckPlayer && npcGetter.FormKey == playerFormKey) { isCheckPlayer = false; return false; } // ignore player
            if (settings.OriginModsToSkip.Contains(npcGetter.FormKey.ModKey)) return false; // ignore npc by origin mod
            if (settings.FlagsToSkip.Any(flag => npcGetter.Configuration.Flags.HasFlag(flag.Flag))) return false; // ignore by configuration flags list
            if (npcGetter.EditorID != null && npcGetter.EditorID.HasAnyFromList(settings.EDIDsToSkip.SkipList)) return false; // ignore by editor id ignore list
            if (settings.EDIDsToSkip.CheckNpcName && npcGetter.Name != null && npcGetter.Name.String.HasAnyFromList(settings.EDIDsToSkip.SkipList)) return false; // ignore by editor id ignore list
            bool isTemplated = npcGetter.Template != null && !npcGetter.Template.IsNull;
            if (isTemplated && npcGetter.Configuration.TemplateFlags.HasFlag(NpcConfiguration.TemplateFlag.Inventory)) return false;
            if (settings.NpcClassesToSkip.Contains(npcGetter.Class)) return false;
            if (settings.NpcCombatStylesToSkip.Contains(npcGetter.CombatStyle.FormKey)) return false;
            // skip by factions. slow!
            //var facNpc = npcGetter;
            //if (isTemplated && npcGetter.Configuration.TemplateFlags.HasFlag(NpcConfiguration.TemplateFlag.Factions) && npcGetter.TryUnTemplate(state.LinkCache, NpcConfiguration.TemplateFlag.Factions, out var untemplatedFactions))
            //{
            //    facNpc = untemplatedFactions;
            //}
            //if (facNpc.Factions != null && facNpc.Factions.Any(f => settings.NpcFactionsToSkip.Contains(f.Faction))) continue;
            if (npcGetter.Factions.Any(f => settings.NpcFactionsToSkip.Contains(f.Faction))) return false;
            // skip by keywords. slow!
            //var kwNpc = npcGetter;
            //if (isTemplated && npcGetter.Configuration.TemplateFlags.HasFlag(NpcConfiguration.TemplateFlag.Keywords) && npcGetter.TryUnTemplate(state.LinkCache, NpcConfiguration.TemplateFlag.Keywords, out var untemplatedKeywords))
            //{
            //    kwNpc = untemplatedKeywords;
            //}
            //if (kwNpc.Keywords != null && kwNpc.Keywords.Any(k => settings.NpcKeywordsToSkip.Contains(k))) continue;
            if (npcGetter.Keywords != null && npcGetter.Keywords.Any(k => settings.NpcKeywordsToSkip.Contains(k))) return false;

            return true;
        }
    }
}
