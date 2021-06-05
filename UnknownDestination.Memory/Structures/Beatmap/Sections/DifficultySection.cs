using System;
using UnknownDestination.Memory.Extensions;
using UnknownDestination.Memory.Unsafe;

namespace UnknownDestination.Memory.Structures.Beatmap.Sections
{
    public class BeatmapDifficultySection : IMarshalReadable
    {
        // Offset 0x8
        public double SliderMultiplier;

        // Offset 0x10
        public double SliderTickRate;

        // Offset 0x2C
        public float ApproachRate;

        // Offset 0x30
        public float CircleSize;

        // Offset 0x34
        public float HpDrainRate;

        // Offset 0x38
        public float OverallDifficulty;
        
        public void Read(IntPtr baseAddress)
        {
            SliderMultiplier = MarshalReader.ReadDouble(baseAddress.Add(0x8));
            SliderTickRate = MarshalReader.ReadDouble(baseAddress.Add(0x10));
            ApproachRate = MarshalReader.ReadSingle(baseAddress.Add(0x2C));
            CircleSize = MarshalReader.ReadSingle(baseAddress.Add(0x30));
            HpDrainRate = MarshalReader.ReadSingle(baseAddress.Add(0x34));
            OverallDifficulty = MarshalReader.ReadSingle(baseAddress.Add(0x38));
        }
    }
}