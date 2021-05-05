using System;
using softnaosu.Game.Memory;
using softnaosu.Game.Signatures;
using softnaosu.Game.Structures.Beatmap.Sections;

namespace softnaosu.Game.Structures.Beatmap
{
    public class Beatmap
    {
        public readonly BeatmapDifficultySection DifficultySection;

        public readonly BeatmapMetadataSection MetadataSection;

        public static IntPtr PointerAddress = 
            (IntPtr) MemoryManager.ReadInt32(Signature.Beatmap.GetBaseAddress());

        public Beatmap()
        {
            DifficultySection = new BeatmapDifficultySection();
            MetadataSection = new BeatmapMetadataSection();
        }
    }
}