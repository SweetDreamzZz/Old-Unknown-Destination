using System;
using softnaosu.Game.Memory;

namespace softnaosu.Game.Structures
{
    public class Beatmap : Structure
    {
        [Offset(0x8)]
        public double DifficultySliderMultiplier;
        
        [Offset(0x10)]
        public double DifficultySliderTickRate;
        
        [Offset(0x18)]
        public string ArtistUnicode;
        
        [Offset(0x1C)]
        public string Artist;
        
        [Offset(0x20)]
        public string Tags;
        
        [Offset(0x24)]
        public string TitleUnicode;
        
        [Offset(0x28)]
        public string Title;
        
        [Offset(0x2C)]
        public float DifficultyApproachRate;
        
        [Offset(0x30)]
        public float DifficultyCircleSize;
        
        [Offset(0x34)]
        public float DifficultyHpDrainRate;
        
        [Offset(0x38)]
        public float DifficultyOverall;
        
        
        public Beatmap(IntPtr address) : base(address)
        {
            
        }
    }
}