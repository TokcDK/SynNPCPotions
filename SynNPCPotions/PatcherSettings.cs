using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis.Settings;
using StringCompareSettings;
using System.Collections.Generic;

namespace SynNPCPotions
{
    public class PatcherSettings
    {
        [SynthesisOrder]
        [SynthesisTooltip("Count of possible item packs")]
        public int PotionsCount = 3;
        [SynthesisTooltip("Chance to appear of item from each pack")]
        public int ChanceOfEach = 75;
        [SynthesisTooltip("Chance to appear of item from each pack")]
        public HashSet<FormLink<IKeywordGetter>> NpcKeywordsToSkip = new()
        {
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Keyword.ActorTypeAnimal,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Keyword.ActorTypeCreature,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Keyword.ActorTypeUndead,
            Mutagen.Bethesda.FormKeys.SkyrimLE.Skyrim.Keyword.ActorTypePrisoner,
        };
    }
}
