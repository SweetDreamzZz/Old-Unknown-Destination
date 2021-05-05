using System;
using softnaosu.Game.Memory;
using softnaosu.Game.Utils;

namespace softnaosu.Game.Structures.Beatmap.Sections
{
    public class BeatmapMetadataSection
    {
        public string ArtistUnicode
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x18;

                return MemoryManager.ReadString(beatmap + offset);
            }
        }

        public string Artist
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x1C;
                
                return MemoryManager.ReadString(beatmap + offset);
            }
        }

        public string Tags
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x20;
                
                return MemoryManager.ReadString(beatmap + offset);
            }
        }

        public string TitleUnicode
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x24;
                
                return MemoryManager.ReadString(beatmap + offset);
            }
        }

        public string Title
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x28;
                
                return MemoryManager.ReadString(beatmap + offset);
            }
        }
        
        public string Creator
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0x78;
                
                return MemoryManager.ReadString(beatmap + offset);
            }
        }
        
        public string Source
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0xA4;
                
                return MemoryManager.ReadString(beatmap + offset);
            }
        }
        
        public string Version
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0xA8;
                
                return MemoryManager.ReadString(beatmap + offset);
            }
        }

        public int BeatmapId
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0xC4;
                
                return MemoryManager.ReadInt32(beatmap + offset);
            }
        }
        
        public int BeatmapSetId
        {
            get
            {
                var beatmap = (IntPtr)MemoryManager.ReadInt32(Beatmap.PointerAddress);
                const int offset = 0xC8;
                
                return MemoryManager.ReadInt32(beatmap + offset);
            }
        }
    }
}