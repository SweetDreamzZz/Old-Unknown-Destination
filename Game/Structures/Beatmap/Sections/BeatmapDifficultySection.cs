using System;
using softnaosu.Game.Memory;
using softnaosu.Game.Utils;

namespace softnaosu.Game.Structures.Beatmap.Sections
{
    public class BeatmapDifficultySection
    {
        public double SliderMultiplier
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x8;
                
                return MemoryManager.ReadDouble(beatmap + offset);
            }
        }
        
        public double SliderTickRate
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x10;
                
                return MemoryManager.ReadDouble(beatmap + offset);
            }
        }
        
        public float ApproachRate
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x2C;
                
                return MemoryManager.ReadSingle(beatmap + offset);
            }
        }
        
        public float CircleSize
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x30;
                
                return MemoryManager.ReadSingle(beatmap + offset);
            }
        }
        
        public float HpDrainRate
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x34;
                
                return MemoryManager.ReadSingle(beatmap + offset);
            }
        }
        
        public float OverallDifficulty
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x38;
                
                return MemoryManager.ReadSingle(beatmap + offset);
            }
        }
    }
}