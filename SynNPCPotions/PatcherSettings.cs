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
    }
}
