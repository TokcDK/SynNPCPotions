using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis.Settings;
using StringCompareSettings;

namespace SynNPCPotions
{
    public class PatcherSettings
    {
        [SynthesisOrder]
        [SynthesisTooltip("Count of possible item packs")]
        public int PotionsCount = 5;
        [SynthesisOrder]
        [SynthesisTooltip("Chance to appear of item from each pack")]
        public int ChanceOfEach = 90;
        [SynthesisOrder]
        [SynthesisTooltip("List of mods to skip if npc from any of them")]
        public HashSet<ModKey> OriginModsToSKip = new();
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
        public HashSet<CustomPackData> CustomPacks = new();
    }
    public class CustomPackData
    {
        [SynthesisOrder]
        [SynthesisTooltip("Check also npc name using EDIDCheckList list")]
        public HashSet<StringCompareSettingGroup> EDIDCheckList = new();
        [SynthesisOrder]
        [SynthesisTooltip("Check also npc name using EDIDCheckList list")]
        public bool CheckNpcName = true;
        [SynthesisOrder]
        [SynthesisTooltip("Custom items count")]
        public int Count = 1;
        [SynthesisOrder]
        [SynthesisTooltip("Custom appear chance of each item")]
        public int Chance = 10;
        [SynthesisOrder]
        [SynthesisTooltip("Check also npc name using EDIDCheckList list")]
        public CustomPackDataItems Items = new();
    }
    public class CustomPackDataItems
    {
        [SynthesisOrder]
        [SynthesisTooltip("Custom leveled item lists to add")]
        public List<FormLink<ILeveledItemGetter>> LeveledItems = new();
        [SynthesisOrder]
        [SynthesisTooltip("Custom items to add")]
        public List<FormLink<IItemGetter>> Items = new();
        [SynthesisOrder]
        [SynthesisTooltip("Custom armors to add?")]
        public List<FormLink<IArmorGetter>> Armors = new();
        [SynthesisOrder]
        [SynthesisTooltip("Custom weapons to add?")]
        public List<FormLink<IWeaponGetter>> Weapons = new();
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
                    new StringCompareSetting() { Name="Atronach", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Corpse", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Beggar", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Victim", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Prisoner", Compare= CompareType.Contains },
                    new StringCompareSetting() { Name="Child", Compare= CompareType.Contains },
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
