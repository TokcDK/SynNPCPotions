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
            var lItemPotionRestoreHealthFormKey = FormKey.Factory("03A16A:Skyrim.esm"); // example leveled list of health restore potions
            var lItemPotionRestoreHealth = state.LinkCache.ResolveContext<ILeveledItem, ILeveledItemGetter>(lItemPotionRestoreHealthFormKey).Record;

            // set in main list
            var item = new CustomItem()
            {
                Items = new HashSet<FormLink<IItemGetter>>() { (FormLink<IItemGetter>)(lItemPotionRestoreHealth as IItemGetter).ToLink() },
                LLICount = 5,
                LLIChance = 10,
            };
            List<CustomItem> items = new() { item };

            var baselVLIToAddFormKey = SetLLI(state, items); // create base lli

            int patchedNpcCount = 0;
            foreach (var npcGetter in state.LoadOrder.PriorityOrder.Npc().WinningOverrides())
            {
                // skip invalid
                if (!IsValidNpc(npcGetter, state, settings)) continue;

                patchedNpcCount++;

                bool isFound = false;
                var lVLIToAddFormKey = FormKey.Null;

                // search custom packs
                foreach (var customPack in settings.CustomPacks)
                {
                    if (!npcGetter.EditorID.HasAnyFromList(customPack.EDIDCheckList)) continue;

                    lVLIToAddFormKey = SetLLI(state, customPack.ItemsToAdd);

                    isFound = true;
                    break;
                }
                if (!isFound) lVLIToAddFormKey = baselVLIToAddFormKey; // set base to add instead

                // add potions list
                var npcEdit = state.PatchMod.Npcs.GetOrAddAsOverride(npcGetter);
                if (npcEdit.Items == null) npcEdit.Items = new Noggog.ExtendedList<ContainerEntry>();
                var entrie = new ContainerEntry { Item = new ContainerItem() };
                entrie.Item.Item.FormKey = lVLIToAddFormKey;
                entrie.Item.Count = 1;
                npcEdit.Items.Add(entrie);
            }

            Console.WriteLine($"Patched {patchedNpcCount} npc records.");
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

        static bool isCheckPlayer = true;
        static FormKey playerFormKey = FormKey.Factory("000007:Skyrim.esm");
        private static bool IsValidNpc(INpcGetter npcGetter, IPatcherState<ISkyrimMod, ISkyrimModGetter> state, PatcherSettings settings)
        {
            if (npcGetter == null) return false;
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
