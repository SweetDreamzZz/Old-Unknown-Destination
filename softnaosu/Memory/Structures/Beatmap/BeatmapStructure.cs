using System.Text;
using softnaosu.Memory.Serialization;
using softnaosu.Memory.Signatures;
using softnaosu.Memory.Structures.Beatmap.Sections;
using softnaosu.Utils;

namespace softnaosu.Memory.Structures.Beatmap
{
    [Offset(0x7)]
    public class BeatmapStructure : StructureBase
    {
        public BeatmapStructureDifficultySection DifficultySection;

        public BeatmapStructureMetadataSection MetadataSection;

        public static BeatmapStructure CurrentNew()
        {
            var baseAddress = ReadStruct(BeatmapSignature.PointerAddress);
            
            var bmapDif = new BeatmapStructureDifficultySection();
            using (var reader = SerializationReader.FromMemoryRegion(baseAddress, bmapDif))
                bmapDif.ReadFromStream(reader);
            
            var bmapMeta = new BeatmapStructureMetadataSection();
            using (var reader = SerializationReader.FromMemoryRegion(baseAddress, bmapMeta))
                bmapMeta.ReadFromStream(reader);

            return new BeatmapStructure
            {
                DifficultySection = bmapDif,
                MetadataSection = bmapMeta,
                BaseAddress = baseAddress
            };
        }

        public static BeatmapStructure Current
        {
            get
            {
                var baseAddress = ReadStruct(BeatmapSignature.PointerAddress);

                return new BeatmapStructure
                {
                    BaseAddress = baseAddress,
                    
                    DifficultySection = new BeatmapStructureDifficultySection
                    {
                        SliderMultiplier = MemoryManager.ReadDouble(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureDifficultySection>("SliderMultiplier"))),
                        
                        SliderTickRate = MemoryManager.ReadDouble(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureDifficultySection>("SliderTickRate"))),

                        ApproachRate = MemoryManager.ReadSingle(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureDifficultySection>("ApproachRate"))),
                        
                        CircleSize = MemoryManager.ReadSingle(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureDifficultySection>("CircleSize"))),
                        
                        HpDrainRate = MemoryManager.ReadSingle(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureDifficultySection>("HpDrainRate"))),
                        
                        OverallDifficulty = MemoryManager.ReadSingle(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureDifficultySection>("OverallDifficulty"))),
                    },
                    
                    MetadataSection = new BeatmapStructureMetadataSection
                    {
                        ArtistUnicode = MemoryManager.ReadString(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureMetadataSection>("ArtistUnicode")), Encoding.UTF8),
                        
                        Artist = MemoryManager.ReadString(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureMetadataSection>("Artist")), Encoding.UTF8),
                        
                        Tags = MemoryManager.ReadString(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureMetadataSection>("Tags")), Encoding.UTF8),
                        
                        TitleUnicode = MemoryManager.ReadString(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureMetadataSection>("TitleUnicode")), Encoding.UTF8),
                        
                        Title = MemoryManager.ReadString(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureMetadataSection>("Title")), Encoding.UTF8),
                        
                        Creator = MemoryManager.ReadString(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureMetadataSection>("Creator")), Encoding.UTF8),
                        
                        Source = MemoryManager.ReadString(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureMetadataSection>("Source")), Encoding.UTF8),
                        
                        Version = MemoryManager.ReadString(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureMetadataSection>("Version")), Encoding.UTF8),
                        
                        BeatmapId = MemoryManager.ReadInt32(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureMetadataSection>("BeatmapId"))),
                        
                        BeatmapSetId = MemoryManager.ReadInt32(Extensions.AddIntPtr(baseAddress,
                            Extensions.GetFieldOffset<BeatmapStructureMetadataSection>("BeatmapSetId")))
                    }
                };
            }
        }
    }
}   