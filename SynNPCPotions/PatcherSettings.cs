using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis.Settings;
using SettingsExtensions;

namespace SynNPCPotions
{
    public class BaseItemsData
    {
        [SynthesisOrder]
        [SynthesisTooltip("Default Health potions is here. Add the items as base if no any from custom packs was set")]
        public BaseItemData? Items1;
        [SynthesisOrder]
        [SynthesisTooltip("Default Magicka potions is here. Add the items as base if no any from custom packs was set")]
        public BaseItemData? Items2;
        [SynthesisOrder]
        [SynthesisTooltip("Default Stamina potions is here. Add the items as base if no any from custom packs was set")]
        public BaseItemData? Items3;
    }

    public class BaseItemData
    {
        [SynthesisOrder]
        [SynthesisTooltip("Ignore Identifiers and add to all npcs which was not ignored by ignore lists")]
        public bool IgnoreIdentifiers = false;
        [SynthesisOrder]
        [SynthesisTooltip("Count of possible item packs")]
        public int LLICount = 5;
        [SynthesisOrder]
        [SynthesisTooltip("Chance to appear of item from each pack")]
        public int LLIChance = 90;
        [SynthesisOrder]
        [SynthesisTooltip("Default Health potions is here. Add the items as base if no any from custom packs was set.")]
        public HashSet<FormLink<IItemGetter>>? ItemsList;
        [SynthesisOrder]
        [SynthesisTooltip($"Edintifiers to add items from {nameof(ItemsList)} by NPC Editor ID")]
        public HashSet<StringCompareSettingGroup>? EDIDIdentifiers;
        [SynthesisOrder]
        [SynthesisTooltip($"Edintifiers to add items from {nameof(ItemsList)} by NPC Class")]
        public HashSet<FormLink<IClassGetter>>? ClassIdentifiers;
    }

    public class PatcherSettings
    {
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
        [SynthesisTooltip("If will found any npc class from here, will skip npc")]
        public HashSet<FormLink<IClassGetter>> NpcClassesToSkip = new()
        {
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.Beggar,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.Child,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassAnimalPredator,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassAnimalPrey,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassAtronachFlame,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassAtronachFrost,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassAtronachStorm,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassBear,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassChaurus,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassDraugrMagic,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassDraugrMelee,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassDraugrMissile,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassDremoraMelee,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassDwarvenCenturion,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassDwarvenSphere,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassDwarvenSpider,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassFalmer,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassFalmerShaman,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassFrostbiteSpider,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassGiant,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassHorker,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassHorse,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassIceWraith,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassMammoth,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassMudCrab,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.Prisoner,
        };
        [SynthesisOrder]
        [SynthesisTooltip("If will found any npc class from here, will skip npc")]
        public HashSet<FormLink<ICombatStyleGetter>> NpcCombatStylesToSkip = new()
        {
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csAtronachFlame,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csAtronachFrost,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csAtronachStorm,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csBear,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csC06WolfSpirit,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csChaurus,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csChicken,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csCow,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDeer,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDog,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugr02Boss,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrBerserker,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrBoss,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrDefensive,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrMagic,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrMagicAllowDual,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrMeleeLvl1,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrMeleeLvl2,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrMeleeLvl3,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrMeleeLvl4,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrMeleeLvl5,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrMeleeLvl6,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrMissile,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrOffensive,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDraugrTank,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDwarvenCenturion,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDwarvenSphere,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDwarvenSpider,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csDwarvenSpiderMagic,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csFrostbiteSpider,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csFrostbiteSpiderMagic,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csGiant,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csGoat,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csGoatWild,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csHorker,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csHorse,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csMammoth,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csIceWraith,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csMudCrab,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csSabreCat,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csSkeever,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csSlaughterfish,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csSpriggan,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csTroll,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csWisp,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csWolf,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csWolfInterior,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.CombatStyle.csWolf_Ice,
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
        [SynthesisTooltip("Will remove Asis 'NPCPotions' script if it is exist in any npc\nThe patcher have no sense when the script added")]
        public bool RemoveNPCPotionsScript = true;
        [SynthesisOrder]
        [SynthesisTooltip("Custom items pack,count and chance to appear. Will override general settings for items(count,chance and items)")]
        public HashSet<ItemsToAddData> ItemsToAdd = ListsData.DefaultLists;
    }

    public class ItemsToAddData
    {
        [SynthesisOrder]
        [SynthesisTooltip($"Include Npc if the Npc EdId is valid and not in {nameof(NpcEdIdExclude)}.")]
        public HashSet<StringCompareSettingGroup> NpcEdIdInclude = new();
        [SynthesisOrder]
        [SynthesisTooltip($"Any npc edid equal of any included here will be skipped")]
        public HashSet<StringCompareSettingGroup> NpcEdIdExclude = new();
        [SynthesisOrder]
        [SynthesisTooltip($"Include Npc class if the Npc class EdId is valid and not in {nameof(NpcEdIdExclude)}.")]
        public HashSet<StringCompareSettingGroup> NpcClassEdIdInclude = new();
        [SynthesisOrder]
        [SynthesisTooltip($"Any npc class edid equal of any included here will be skipped")]
        public HashSet<StringCompareSettingGroup> NpcClassEdIdExclude = new();
        [SynthesisOrder]
        [SynthesisTooltip("Items list to add")]
        public HashSet<LeveledItemToAddData> Items = new();
    }

    public class LeveledItemToAddData
    {
        [SynthesisOrder]
        [SynthesisTooltip($"LeveledItem editor id")]
        public string EDID { get; set; } = "";
        [SynthesisOrder]
        [SynthesisTooltip($"Count of item record.\nWhen set {nameof(LeveledItem.Flag.CalculateFromAllLevelsLessThanOrEqualPlayer)} flag, item will appear only when value is lesser of player's current level.")]
        public int Level = 1;
        [SynthesisOrder]
        [SynthesisTooltip($"Count of item record.\nWhen set {nameof(LeveledItem.Flag.CalculateForEachItemInCount)} flag, it will set copies count with standalone chance for each.")]
        public int Count = 1;
        [SynthesisOrder]
        [SynthesisTooltip($"Appear % chance of item.\nWhen set {nameof(LeveledItem.Flag.CalculateForEachItemInCount)} flag, chance will be calculated {nameof(Count)} times like it different items")]
        public int Chance = 10;
        [SynthesisOrder]
        [SynthesisTooltip($"Item leveled list flags. "
            + $"\n\n{nameof(LeveledItem.Flag.CalculateForEachItemInCount)} flag will make calculate appear chance {nameof(Count)} times like like it {nameof(Count)} copies of item."
            + $"\n{nameof(LeveledItem.Flag.CalculateFromAllLevelsLessThanOrEqualPlayer)} flag will make possible to appear the item only when level of player is same or greater of npc for which item was added."
            + $"\n{nameof(LeveledItem.Flag.UseAll)} flag will make a chance for all items in list to appear at once."
            )]
        public LeveledItem.Flag LLIFlags = LeveledItem.Flag.CalculateForEachItemInCount | LeveledItem.Flag.CalculateFromAllLevelsLessThanOrEqualPlayer | LeveledItem.Flag.UseAll;
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
