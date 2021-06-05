using UnknownDestination.Memory.Structures.Beatmap.Sections;
using UnknownDestination.Memory.Unsafe;

namespace UnknownDestination.Memory.Structures.Beatmap
{
    public class Beatmap : StructureBase
    {
        public BeatmapDifficultySection DifficultySection;
        
        public BeatmapMetadataSection MetadataSection;

        public static Beatmap Current => GetCurrentBeatmap();

        private static Beatmap GetCurrentBeatmap()
        {
            var pointer = MarshalReader.ReadIntPtr(Signatures.Signatures.Beatmap.Address);
            var baseAddress = MarshalReader.ReadIntPtr(pointer);

            var difficultySection = new BeatmapDifficultySection();
            difficultySection.Read(baseAddress);
            
            var metadataSection = new BeatmapMetadataSection();
            metadataSection.Read(baseAddress);
            
            return new Beatmap
            {
                BaseAddress = baseAddress,
                
                DifficultySection = difficultySection,
                MetadataSection = metadataSection
            };
        }
    }
}