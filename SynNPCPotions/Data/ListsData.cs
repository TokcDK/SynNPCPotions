using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using SynNPCPotions.Helpers;

namespace SynNPCPotions.Data
{
    public static class ListsData
    {
        public static HashSet<ItemsToAddData> DefaultLists { get; internal set; } = new HashSet<ItemsToAddData>()
        {
            new ItemsToAddData()
            {
                NpcEdIdInclude = new HashSet<StringCompareSettingGroup>()
                {
                    new StringCompareSettingGroup()
                    {
                         StringsList = new List<StringCompareSetting>()
                         {
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
                NpcEdIdExclude = new HashSet<StringCompareSettingGroup>(),
                NpcClassEdIdInclude = new HashSet<StringCompareSettingGroup>()
                {
                    new StringCompareSettingGroup()
                    {
                        StringsList = new List<StringCompareSetting>()
                        {
                            new StringCompareSetting()
                            {
                                Name = "Blade,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatBarbarian,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatWarrior1H,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatWarrior2H,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatWitchblade,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CWSoldierClass,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassAlikrMelee,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassForsworn,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassThalmorMelee,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassWerewolf,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassWerewolfBoss,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "GuardImperial,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "GuardOrc1H,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "GuardOrc2H,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "GuardSonsSkyrim,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "Jailor,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "SoldierImperialNotGuard,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "SoldierSonsSkyrimNotGuard,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerBlockExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerBlockMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerHeavyArmorExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerHeavyArmorMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerOneHandedExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerOneHandedJourneyman,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerOneHandedMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerTwoHandedExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerTwoHandedMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "DLC2EbonyWarriorClass,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                        }
                    }
                },
                NpcClassEdIdExclude= new HashSet<StringCompareSettingGroup>(),
                Items = new HashSet<LeveledItemToAddData>()
                {
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 60,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealth.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 30,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealth.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 10,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealthBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 20,
                        Count= 1,
                        Chance= 20,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealthBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 30,
                        Count= 1,
                        Chance= 30,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealthBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 40,
                        Count= 1,
                        Chance= 40,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealthBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 10,
                        Count= 1,
                        Chance= 10,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreMagicka.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 20,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStamina.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 20,
                        Count= 1,
                        Chance= 20,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStamina.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 40,
                        Count= 2,
                        Chance= 40,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStaminaBest.FormKey,
                        }
                    },
                }
            },
            new ItemsToAddData()
            {
                NpcEdIdInclude = new HashSet<StringCompareSettingGroup>()
                {
                    new StringCompareSettingGroup()
                    {
                         StringsList = new List<StringCompareSetting>()
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
                NpcEdIdExclude = new HashSet<StringCompareSettingGroup>(),
                NpcClassEdIdInclude = new HashSet<StringCompareSettingGroup>()
                {
                    new StringCompareSettingGroup()
                    {
                        StringsList = new List<StringCompareSetting>()
                        {
                            new StringCompareSetting()
                            {
                                Name = "Bard,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatMageConjurer,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatMageDestruction,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatMageElemental,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatMageNecro,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatMystic,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatSorcerer,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatSpellsword,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatWitchblade,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassAlikrWizard,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassBanditWizard,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassForswornShaman,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassThalmorWizard,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassWerewolfMage,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerAlchemyExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerAlchemyJourneyman,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerAlchemyMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerAlterationExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerAlterationMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerConjurationExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerConjurationJourneyman,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerConjurationMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerDestructionExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerDestructionJourneyman,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerDestructionMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerEnchantingExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerEnchantingMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerIllusionExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerIllusionMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerRestorationExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerRestorationJourneyman,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerRestorationMaster",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatWitchblade",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatSpellsword",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatMonk",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                        }
                    }
                },
                NpcClassEdIdExclude= new HashSet<StringCompareSettingGroup>(),
                Items = new HashSet<LeveledItemToAddData>()
                {
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 60,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreMagicka.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 30,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreMagicka.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 10,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreMagickaBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 20,
                        Count= 1,
                        Chance= 30,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreMagickaBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 40,
                        Count= 1,
                        Chance= 40,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreMagickaBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 20,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealth.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 20,
                        Count= 1,
                        Chance= 20,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealthBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 10,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStamina.FormKey,
                        }
                    },
                }
            },
            new ItemsToAddData()
            {
                NpcEdIdInclude = new HashSet<StringCompareSettingGroup>()
                {
                    new StringCompareSettingGroup()
                    {
                         StringsList = new List<StringCompareSetting>()
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
                                   Name = "Boss",
                                   Compare= CompareType.Contains,
                                   IgnoreCase = true,
                              },
                         }
                    }
                },
                NpcEdIdExclude = new HashSet<StringCompareSettingGroup>(),
                NpcClassEdIdInclude = new HashSet<StringCompareSettingGroup>()
                {
                    new StringCompareSettingGroup()
                    {
                        StringsList = new List<StringCompareSetting>()
                        {
                            new StringCompareSetting()
                            {
                                Name = "CombatAssassin,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatNightblade,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatNightingale,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatRanger,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatRogue,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatScout,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "CombatThief,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassAlikrMissile,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassForswornMissile,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "EncClassThalmorMissile,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerLightArmorExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerLightArmorJourneyman,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerLightArmorMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerMarksmanExpert,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerMarksmanJourneyman,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                            new StringCompareSetting()
                            {
                                Name = "TrainerMarksmanMaster,",
                                Compare = CompareType.Equals,
                                IgnoreCase = true,
                            },
                        }
                    }
                },
                NpcClassEdIdExclude= new HashSet<StringCompareSettingGroup>(),
                Items = new HashSet<LeveledItemToAddData>()
                {
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 60,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStamina.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 30,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStamina.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 10,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStaminaBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 20,
                        Count= 1,
                        Chance= 30,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStaminaBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 40,
                        Count= 1,
                        Chance= 40,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreStaminaBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 30,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealth.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 20,
                        Count= 1,
                        Chance= 40,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealthBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 40,
                        Count= 1,
                        Chance= 40,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreHealthBest.FormKey,
                        }
                    },
                    new LeveledItemToAddData()
                    {
                        Level= 1,
                        Count= 1,
                        Chance= 15,
                        Items = new HashSet<FormLink<IItemGetter>>()
                        {
                            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.LeveledItem.LItemPotionRestoreMagicka.FormKey,
                        }
                    },
                }
            },
        };
    }
}
