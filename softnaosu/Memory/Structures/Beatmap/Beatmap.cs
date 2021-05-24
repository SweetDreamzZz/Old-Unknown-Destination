using System.Text;
using softnaosu.Memory.Serialization;
using softnaosu.Memory.Signatures;
using softnaosu.Memory.Structures.Beatmap.Sections;
using softnaosu.Objects;
using softnaosu.Utils;

namespace softnaosu.Memory.Structures.Beatmap
{
    public class Beatmap : StructureBase
    {
        public BeatmapDifficultySection DifficultySection;

        public BeatmapMetadataSection MetadataSection;

        public static Beatmap Current => GetCurrent();

        private static Beatmap GetCurrent()
        {
            var baseAddress = ReadPointerBaseAddress(BeatmapSignature.PointerAddress);

            var beatmapDifficultySection = new BeatmapDifficultySection();
            using var difficultySectionReader = SerializationReader.FromMemoryRegion(baseAddress, beatmapDifficultySection);
            beatmapDifficultySection.ReadFromStream(difficultySectionReader);

            var beatmapMetadataSection = new BeatmapMetadataSection();
            using var metadataSectionReader = SerializationReader.FromMemoryRegion(baseAddress, beatmapMetadataSection);
            beatmapMetadataSection.ReadFromStream(metadataSectionReader);

            return new Beatmap
            {
                BaseAddress = baseAddress,
                
                DifficultySection = beatmapDifficultySection,
                MetadataSection = beatmapMetadataSection
            };
        }
    }
}   