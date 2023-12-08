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
        [SynthesisTooltip("Add the items as base if no any from custom packs was set")]
        public BaseItemsData BaseItems = new() { 
            Items1 = new BaseItemData()
            {
                ItemsList = new() { Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealth.FormKey },
                IgnoreIdentifiers = true
            },
            Items2 = new BaseItemData() 
            { 
                ItemsList = new() 
                { 
                    Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreMagicka.FormKey,
                },
                EDIDIdentifiers = new HashSet<StringCompareSettingGroup>()
                {
                    new StringCompareSettingGroup()
                    {
                         StringsList=new List<StringCompareSetting>()
                         {
                              new StringCompareSetting()
                              {
                                   Name = "Magic",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Mage",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Spell",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Caster",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Vigilant",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Vampire",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Necromancer",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Necromancer",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Priest",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Warlock",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Boss",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                         }
                    }
                },
                ClassIdentifiers= new HashSet<FormLink<IClassGetter>>()
                {
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.Bard,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatMageConjurer,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatMageDestruction,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatMageElemental,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatMageNecro,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatMystic,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatSorcerer,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatSpellsword,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatWitchblade,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassAlikrWizard,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassBanditWizard,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassForswornShaman,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassThalmorWizard,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassWerewolfMage,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerAlchemyExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerAlchemyJourneyman,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerAlchemyMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerAlterationExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerAlterationMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerConjurationExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerConjurationJourneyman,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerConjurationMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerDestructionExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerDestructionJourneyman,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerDestructionMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerEnchantingExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerEnchantingMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerIllusionExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerIllusionMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerRestorationExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerRestorationJourneyman,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerRestorationMaster,
                }
            },
            Items3 = new BaseItemData() 
            { 
                ItemsList = new() 
                { 
                    Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStamina.FormKey
                },
                EDIDIdentifiers = new HashSet<StringCompareSettingGroup>()
                {
                    new StringCompareSettingGroup()
                    {
                         StringsList=new List<StringCompareSetting>()
                         {
                              new StringCompareSetting()
                              {
                                   Name = "Missile",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Ranged",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Ranger",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Warrior",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Melee",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Warrior",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Vigilant",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                              new StringCompareSetting()
                              {
                                   Name = "Boss",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                         }
                    }
                },

                ClassIdentifiers = new HashSet<FormLink<IClassGetter>>()
                {
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.Blade,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatAssassin,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatBarbarian,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatMonk,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatNightblade,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatNightingale,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatRanger,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatRogue,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatScout,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatSpellsword,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatThief,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatWarrior1H,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatWarrior2H,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CombatWitchblade,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.CWSoldierClass,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassAlikrMelee,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassAlikrMissile,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassForsworn,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassForswornMissile,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassThalmorMelee,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassThalmorMissile,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassWerewolf,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.EncClassWerewolfBoss,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.GuardImperial,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.GuardOrc1H,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.GuardOrc2H,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.GuardSonsSkyrim,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.Jailor,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.SoldierImperialNotGuard,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.SoldierSonsSkyrimNotGuard,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerBlockExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerBlockMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerHeavyArmorExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerHeavyArmorMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerLightArmorExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerLightArmorJourneyman,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerLightArmorMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerMarksmanExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerMarksmanJourneyman,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerMarksmanMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerOneHandedExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerOneHandedJourneyman,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerOneHandedMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerTwoHandedExpert,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Class.TrainerTwoHandedMaster,
                     Mutagen.Bethesda.FormKeys.SkyrimLE.Dragonborn.Class.DLC2EbonyWarriorClass,
                }
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
