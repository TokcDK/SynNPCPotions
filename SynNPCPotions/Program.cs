using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;

namespace SynNPCPotions
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "YourPatcher.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            var lItemPotionRestoreHealthFormKey = FormKey.Factory("03A16A:Skyrim.esm"); // example leveled list of health restore potions
            var lItemPotionRestoreHealth = state.LinkCache.ResolveContext<ILeveledItem, ILeveledItemGetter>(lItemPotionRestoreHealthFormKey);

            // create leveled itema list
            var lVLIHealthPotions = state.PatchMod.LeveledItems.AddNew(); // Sublist including item records which will be added with selected chance
            lVLIHealthPotions.EditorID = "LItemGeneratedNPCPotionsHealthSub";
            lVLIHealthPotions.ChanceNone = 90; // here chance to add, 10% if 90
            lVLIHealthPotions.Flags |= LeveledItem.Flag.CalculateForEachItemInCount; // also calculate each sublist
            lVLIHealthPotions.Flags |= LeveledItem.Flag.CalculateFromAllLevelsLessThanOrEqualPlayer; // when list is set with settings to be added only from some level
            lVLIHealthPotions.Entries = new Noggog.ExtendedList<LeveledItemEntry>();

            // here add specific pack of leveled entries inside, maybe set in settings
            var LVLIEntrieHealth = new LeveledItemEntry
            {
                Data = new LeveledItemEntryData
                {
                    Level = 1,
                    Count = 1,
                    Reference = lItemPotionRestoreHealth.Record.ToLink()
                }
            };

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
            for (int i = 0; i < 5; i++) // here we use count of added items
            {
                lVLIToAdd.Entries.Add(LVLIEntrie);
            }

        }
    }
}
