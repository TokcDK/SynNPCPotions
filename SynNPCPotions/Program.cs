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
            var lItemPotionRestoreHealth = state.LinkCache.ResolveContext<ILeveledItem, ILeveledItemGetter>(lItemPotionRestoreHealthFormKey);

            // create leveled itema list
            var lVLIHealthPotions = state.PatchMod.LeveledItems.AddNew(); // Sublist including item records which will be added with selected chance
            lVLIHealthPotions.EditorID = "LItemGeneratedNPCPotionsHealthSub";
            lVLIHealthPotions.ChanceNone = (byte)(100 - settings.ChanceOfEach); // here chance to add, 10% if 90
            lVLIHealthPotions.Flags |= LeveledItem.Flag.CalculateForEachItemInCount; // also calculate each sublist
            lVLIHealthPotions.Flags |= LeveledItem.Flag.CalculateFromAllLevelsLessThanOrEqualPlayer; // when list is set with settings to be added only from some level
            lVLIHealthPotions.Entries = new Noggog.ExtendedList<LeveledItemEntry>();

            // here add specific pack of leveled entries inside, maybe set in settings
            // entries can be many, from some lists from patcher settings
            var LVLIEntrieHealth = new LeveledItemEntry
            {
                Data = new LeveledItemEntryData
                {
                    Level = 1,
                    Count = 1,
                    Reference = lItemPotionRestoreHealth.Record.ToLink()
                }
            };
            lVLIHealthPotions.Entries.Add(LVLIEntrieHealth);

            // set in main list
            var lVLIToAdd = state.PatchMod.LeveledItems.AddNew(); // main leveled items list, which will be added to valid npcs
            lVLIToAdd.EditorID = "LItemGeneratedNPCPotions";
            lVLIToAdd.ChanceNone = 0; // 100%
            lVLIToAdd.Flags |= LeveledItem.Flag.UseAll; // all record will be calculated
            lVLIToAdd.Entries = new Noggog.ExtendedList<LeveledItemEntry>();

            var LVLIEntrie = new LeveledItemEntry
            {
                Data = new LeveledItemEntryData
                {
                    Level = 1,
                    Count = 1,
                    Reference = lVLIHealthPotions.ToLink() // set sublist with potions
                }
            };
            for (int i = 0; i < settings.PotionsCount; i++) // here we use count of added items
            {
                lVLIToAdd.Entries.Add(LVLIEntrie);
            }

            bool isCheckPlayer = true;
            FormKey playerFormKey = FormKey.Factory("000007:Skyrim.esm");

            int patchedNpcCount = 0;
            foreach (var npcGetter in state.LoadOrder.PriorityOrder.Npc().WinningOverrides())
            {
                // skip invalid
                if (npcGetter == null) continue;
                if (npcGetter.IsDeleted) continue;
                if (isCheckPlayer && npcGetter.FormKey == playerFormKey) { isCheckPlayer = false; continue; } // ignore player
                if (settings.OriginModsToSKip.Contains(npcGetter.FormKey.ModKey)) continue; // ignore npc by origin mod
                if (settings.FlagsToSkip.Any(flag => npcGetter.Configuration.Flags.HasFlag(flag.Flag))) continue; // ignore by configuration flags list                
                if (npcGetter.EditorID!=null && npcGetter.EditorID.HasAnyFromList(settings.EDIDsToSKip)) continue; // ignore by editor id ignore list
                bool isTemplated = npcGetter.Template != null && !npcGetter.Template.IsNull;
                if (isTemplated && npcGetter.Configuration.TemplateFlags.HasFlag(NpcConfiguration.TemplateFlag.Inventory)) continue;
                // skip by keywords. slow!
                //var kwNpc = npcGetter;
                //if (isTemplated && npcGetter.Configuration.TemplateFlags.HasFlag(NpcConfiguration.TemplateFlag.Keywords) && npcGetter.TryUnTemplate(state.LinkCache, NpcConfiguration.TemplateFlag.Keywords, out var untemplatedKeywords))
                //{
                //    kwNpc = untemplatedKeywords;
                //}
                //if (kwNpc.Keywords != null && kwNpc.Keywords.Any(k => settings.NpcKeywordsToSkip.Contains(k))) continue;
                if (npcGetter.Keywords != null && npcGetter.Keywords.Any(k => settings.NpcKeywordsToSkip.Contains(k))) continue;
                // skip by factions. slow!
                //var facNpc = npcGetter;
                //if (isTemplated && npcGetter.Configuration.TemplateFlags.HasFlag(NpcConfiguration.TemplateFlag.Factions) && npcGetter.TryUnTemplate(state.LinkCache, NpcConfiguration.TemplateFlag.Factions, out var untemplatedFactions))
                //{
                //    facNpc = untemplatedFactions;
                //}
                //if (facNpc.Factions != null && facNpc.Factions.Any(f => settings.NpcFactionsToSkip.Contains(f.Faction))) continue;
                if (npcGetter.Factions != null && npcGetter.Factions.Any(f => settings.NpcFactionsToSkip.Contains(f.Faction))) continue;

                patchedNpcCount++;

                // add potions list
                var npcEdit = state.PatchMod.Npcs.GetOrAddAsOverride(npcGetter);
                if (npcEdit.Items == null) npcEdit.Items = new Noggog.ExtendedList<ContainerEntry>();
                var entrie = new ContainerEntry
                {
                    Item = new ContainerItem()
                };
                entrie.Item.Item.FormKey = lVLIToAdd.FormKey;
                entrie.Item.Count = 1;
                npcEdit.Items.Add(entrie);
            }

            Console.WriteLine($"Patched {patchedNpcCount} npc records.");
        }
    }
}
