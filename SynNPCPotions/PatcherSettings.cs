﻿using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis.Settings;
using StringCompareSettings;

namespace SynNPCPotions
{
    public class PatcherSettings
    {
        [SynthesisOrder]
        [SynthesisTooltip("Count of possible item packs")]
        public int PotionsCount = 3;
        [SynthesisOrder]
        [SynthesisTooltip("Chance to appear of item from each pack")]
        public int ChanceOfEach = 75;
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
        };
        [SynthesisOrder]
        [SynthesisTooltip("Strings data determine npc ignore by editor id")]
        public HashSet<NpcConfigurationFlag> FlagsToSkip = new()
        {
             new NpcConfigurationFlag(){Flag=NpcConfiguration.Flag.IsGhost},
             new NpcConfigurationFlag(){Flag=NpcConfiguration.Flag.IsCharGenFacePreset},
             new NpcConfigurationFlag(){Flag=NpcConfiguration.Flag.Summonable},
        };
        [SynthesisOrder]
        [SynthesisTooltip("Strings data determine npc ignore by editor id")]
        public HashSet<StringCompareSettingGroup> EDIDsToSKip = new()
        {
            new StringCompareSettingGroup()
            {
                StringsList = new List<StringCompareSetting>()
                {
                    new StringCompareSetting() { Name="VoiceType", Compare= CompareType.StartsWith },
                    new StringCompareSetting() { Name="AudioTemplate", Compare= CompareType.StartsWith },
                }
            }
        };
    }

    public class NpcConfigurationFlag
    {
        public NpcConfiguration.Flag Flag;
    }
}
