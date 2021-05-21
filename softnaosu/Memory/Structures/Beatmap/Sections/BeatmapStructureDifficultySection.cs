using softnaosu.Memory.Serialization;

namespace softnaosu.Memory.Structures.Beatmap.Sections
{
    public class BeatmapStructureDifficultySection : IMemoryDeserializable
    {
        [Offset(0x8)] public double SliderMultiplier;

        [Offset(0x10)] public double SliderTickRate;

        [Offset(0x2C)] public float ApproachRate;

        [Offset(0x30)] public float CircleSize;

        [Offset(0x34)] public float HpDrainRate;

        [Offset(0x38)] public float OverallDifficulty;

        public int GetLength()
        {
            return 0x38 + sizeof(float); // biggest offset + syzeof(type)
        }

        public void ReadFromStream(SerializationReader reader)
        {
            reader.ReadBytes(8); // skip 8 bytes
            SliderMultiplier = reader.ReadDouble();
            SliderTickRate = reader.ReadDouble();
            reader.ReadBytes(12); // skip 12 bytes
            ApproachRate = reader.ReadSingle();
            CircleSize = reader.ReadSingle();
            HpDrainRate = reader.ReadSingle();
            OverallDifficulty = reader.ReadSingle();
        }
    }
}