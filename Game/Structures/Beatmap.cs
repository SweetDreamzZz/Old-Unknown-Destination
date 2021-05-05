using System;
using softnaosu.Game.Memory;
using softnaosu.Game.Signatures;
using softnaosu.Game.Utils;

namespace softnaosu.Game.Structures
{
    public class Beatmap
    {
        [Offset(0x8)]
        public readonly double DifficultySliderMultiplier;
        
        [Offset(0x10)]
        public readonly double DifficultySliderTickRate;
        
        [Offset(0x18)]
        public readonly string ArtistUnicode;
        
        [Offset(0x1C)]
        public readonly string Artist;
        
        [Offset(0x20)]
        public readonly string Tags;
        
        [Offset(0x24)]
        public readonly string TitleUnicode;
        
        [Offset(0x28)]
        public readonly string Title;
        
        [Offset(0x2C)]
        public readonly float DifficultyApproachRate;
        
        [Offset(0x30)]
        public readonly float DifficultyCircleSize;
        
        [Offset(0x34)]
        public readonly float DifficultyHpDrainRate;
        
        [Offset(0x38)]
        public readonly float DifficultyOverall;
        
        public Beatmap()
        {
            var pointer = (IntPtr)MemoryManager.ReadInt32(Signature.Beatmap.GetBaseAddress());
            var beatmap = (IntPtr)MemoryManager.ReadInt32(pointer);

            DifficultySliderMultiplier = MemoryManager.ReadDouble(Extensions.Add(beatmap, 
                Extensions.GetFieldOffset<Beatmap>("DifficultySliderMultiplier")));

            DifficultySliderTickRate = MemoryManager.ReadDouble(Extensions.Add(beatmap,
                Extensions.GetFieldOffset<Beatmap>("DifficultySliderTickRate")));

            ArtistUnicode = MemoryManager.ReadString(Extensions.Add(beatmap,
                Extensions.GetFieldOffset<Beatmap>("ArtistUnicode")));
            
            Artist = MemoryManager.ReadString(Extensions.Add(beatmap,
                Extensions.GetFieldOffset<Beatmap>("Artist")));
            
            Tags = MemoryManager.ReadString(Extensions.Add(beatmap,
                Extensions.GetFieldOffset<Beatmap>("Tags")));
            
            TitleUnicode = MemoryManager.ReadString(Extensions.Add(beatmap,
                Extensions.GetFieldOffset<Beatmap>("TitleUnicode")));
            
            Title = MemoryManager.ReadString(Extensions.Add(beatmap,
                Extensions.GetFieldOffset<Beatmap>("Title")));
            
            DifficultyApproachRate = MemoryManager.ReadSingle(Extensions.Add(beatmap,
                Extensions.GetFieldOffset<Beatmap>("DifficultyApproachRate")));
            
            DifficultyCircleSize = MemoryManager.ReadSingle(Extensions.Add(beatmap,
                Extensions.GetFieldOffset<Beatmap>("DifficultyCircleSize")));
            
            DifficultyHpDrainRate = MemoryManager.ReadSingle(Extensions.Add(beatmap,
                Extensions.GetFieldOffset<Beatmap>("DifficultyHpDrainRate")));
            
            DifficultyOverall = MemoryManager.ReadSingle(Extensions.Add(beatmap,
                Extensions.GetFieldOffset<Beatmap>("DifficultyOverall")));
        }
    }
}