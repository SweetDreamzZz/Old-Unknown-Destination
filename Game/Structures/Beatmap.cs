using System;

namespace softnaosu.Structures
{
    public class Beatmap : Structure
    {
        public string Title;
        public string TitleUnicode;
        public string Artist;
        public string ArtistUnicode;
        public string Tags;

        public float DifficultyOverall;
        public float DifficultyHpDrainRate;
        public float DifficultyCircleSize;
        public float DifficultyApproachRate;

        public double DifficultySliderTickRate;
        public double DifficultySliderMultiplier;

        public Beatmap(IntPtr address) : base(address)
        {
            var pointer = GetPointer();
            
            
        }
        
        
    }
}