using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis.Settings;
using StringCompareSettings;

namespace SynNPCPotions
{
    public class BaseItemsData
    {
        [SynthesisOrder]
        [SynthesisTooltip("Count of possible item packs")]
        public int LLICount = 5;
        [SynthesisOrder]
        [SynthesisTooltip("Chance to appear of item from each pack")]
        public int LLIChance = 90;
        [SynthesisOrder]
        [SynthesisTooltip("Default Health potions is here. Add the items as base if no any from custom packs was set")]
        public HashSet<FormLink<IItemGetter>>? Items1;
        [SynthesisOrder]
        [SynthesisTooltip("Default Magicka potions is here. Add the items as base if no any from custom packs was set")]
        public HashSet<FormLink<IItemGetter>>? Items2;
        [SynthesisOrder]
        [SynthesisTooltip("Default Stamina potions is here. Add the items as base if no any from custom packs was set")]
        public HashSet<FormLink<IItemGetter>>? Items3;
    }

    public class PatcherSettings
    {
        [SynthesisOrder]
        [SynthesisTooltip("Add the items as base if no any from custom packs was set")]
        public BaseItemsData BaseItems = new() { 
            Items1 = new()
            {
                Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealth.FormKey.ToLink<IItemGetter>()
            },
            Items2 = new()
            {
                Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreMagicka.FormKey.ToLink<IItemGetter>()
            },
            Items3 = new()
            {
                Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStamina.FormKey.ToLink<IItemGetter>()
            },
        };
        [SynthesisOrder]
        [SynthesisTooltip("List of mods to skip if npc from any of them")]
        public HashSet<ModKey> OriginModsToSkip = new();
        [SynthesisOrder]
        [SynthesisTooltip("If will found any npc keyword from here, will skip npc")]
        public HashSet<FormLink<IKeywordGetter>> NpcKeywordsToSkip = new()
        {
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Keyword.ActorTypeAnimal,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Keyword.ActorTypeCreature,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Keyword.ActorTypeUndead,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Keyword.ActorTypeDaedra,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Keyword.ActorTypePrisoner,
        };
        [SynthesisOrder]
        [SynthesisTooltip("If will found any npc faction from here, will skip npc")]
        public HashSet<FormLink<IFactionGetter>> NpcFactionsToSkip = new()
        {
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.CreatureFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.PreyFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.PredatorFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.FarmAnimalsFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.FoxFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.WolfFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.SabreCatFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.DragonFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.MammothFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.AtronachFlameFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.AtronachFrostFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.AtronachStormFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.SprigganPredatorFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.SprigganPreyFaction,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Faction.HunterPreyFaction,
        };
        [SynthesisOrder]
        [SynthesisTooltip("Configuration flags list to skip npcs with attached any of them")]
        public HashSet<NpcConfigurationFlag> FlagsToSkip = new()
        {
             new NpcConfigurationFlag(){Flag=NpcConfiguration.Flag.IsGhost},
             new NpcConfigurationFlag(){Flag=NpcConfiguration.Flag.IsCharGenFacePreset},
             new NpcConfigurationFlag(){Flag=NpcConfiguration.Flag.Summonable},
        };
        [SynthesisOrder]
        [SynthesisTooltip("Settings to skip by editor id and name")]
        [SynthesisSettingName("EDIDsToSkip")]
        public EDIDSkipSettings EDIDsToSkip = new();
        [SynthesisOrder]
        [SynthesisTooltip("Custom items pack,count and chance to appear. Will override general settings for items(count,chance and items)")]
        public HashSet<CustomPack> CustomPacks = new();
    }

    public class CustomPack
    {
        [SynthesisOrder]
        [SynthesisTooltip("Check also npc name using EDIDCheckList list")]
        public HashSet<StringCompareSettingGroup> EDIDCheckList = new();
        [SynthesisOrder]
        [SynthesisTooltip("Check also npc name using EDIDCheckList list")]
        public bool CheckNpcName = true;
        [SynthesisOrder]
        [SynthesisTooltip("Items list to add")]
        public HashSet<CustomItem> ItemsToAdd = new();
    }

    public class CustomItem
    {
        [SynthesisOrder]
        [SynthesisTooltip($"Count of item record.\nWhen set {nameof(LeveledItem.Flag.CalculateFromAllLevelsLessThanOrEqualPlayer)} flag, item will appear only when value is lesser of player's current level.")]
        public int LLILevel = 1;
        [SynthesisOrder]
        [SynthesisTooltip($"Count of item record.\nWhen set {nameof(LeveledItem.Flag.CalculateForEachItemInCount)} flag, it will set copies count with standalone chance for each.")]
        public int LLICount = 1;
        [SynthesisOrder]
        [SynthesisTooltip($"Appear chance of item.\nWhen set {nameof(LeveledItem.Flag.CalculateForEachItemInCount)} flag, chance will be calculated {nameof(LLICount)} times like it different items")]
        public int LLIChance = 10;
        [SynthesisOrder]
        [SynthesisTooltip($"Item leveled list flags. "
            + $"\n\n{nameof(LeveledItem.Flag.CalculateForEachItemInCount)} flag will make calculate appear chance {nameof(LLICount)} times like like it {nameof(LLICount)} copies of item."
            + $"\n{nameof(LeveledItem.Flag.CalculateFromAllLevelsLessThanOrEqualPlayer)} flag will make possible to appear the item only when level of player is same or greater of npc for which item was added."
            + $"\n{nameof(LeveledItem.Flag.UseAll)} flag will make a chance for all items in list to appear at once."
            )]
        public HashSet<ItemLLIFlag> LLIFlags = new()
        {
            new ItemLLIFlag() { Flag = LeveledItem.Flag.CalculateForEachItemInCount },
            new ItemLLIFlag() { Flag = LeveledItem.Flag.CalculateFromAllLevelsLessThanOrEqualPlayer },
        };
        [SynthesisOrder]
        [SynthesisTooltip("Items to add in the list")]
        public HashSet<FormLink<IItemGetter>> Items = new();
    }

    public class ItemLLIFlag
    {
        [SynthesisTooltip("Item leveled list flag")]
        public LeveledItem.Flag Flag;
    }

    public class EDIDSkipSettings
    {
        [SynthesisOrder]
        [SynthesisTooltip("Strings data determine npc ignore by editor id")]
        public HashSet<StringCompareSettingGroup> SkipList = new()
        {
            new StringCompareSettingGroup()
            {
                StringsList = new List<StringCompareSetting>()
                {
                    new StringCompareSetting() { Name="VoiceType", Compare= CompareType.StartsWith },
                    new StringCompareSetting() { Name="AudioTemplate", Compare= CompareType.StartsWith },
                    new StringCompareSetting() { Name="Dwarven", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Skeleton", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Draugr", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Atronach", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Corpse", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Beggar", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Victim", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Prisoner", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Child", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Android", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="dummy", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="CB2_", Compare = CompareType.StartsWith },
                    new StringCompareSetting() { Name="aaaBreed", Compare= CompareType.StartsWith },
                    new StringCompareSetting() { Name="^.*Slave[^r]{0,1}.*$", Compare= CompareType.Regex, Comment="slave but not slaver"},
                }
            }
        };
        [SynthesisOrder]
        [SynthesisTooltip("Check also npc name using skip list")]
        public bool CheckNpcName = true;
    }

    public class NpcConfigurationFlag
    {
        [SynthesisTooltip("Configuration flag to skip npc")]
        public NpcConfiguration.Flag Flag;
    }
}
