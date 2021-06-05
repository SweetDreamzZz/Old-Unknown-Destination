using System;
using UnknownDestination.Memory.Extensions;
using UnknownDestination.Memory.Unsafe;

namespace UnknownDestination.Memory.Structures.Beatmap.Sections
{
    public class BeatmapMetadataSection : IMarshalReadable
    {
        // Offset 0x18
        public string ArtistUnicode;

        // Offset 0x1C
        public string Artist;

        // Offset 0x20
        public string Tags;
        
        // Offset 0x24
        public string TitleUnicode;

        // Offset 0x28
        public string Title;

        // Offset 0x78
        public string Creator;

        // Offset 0xA4
        public string Source;

        // Offset 0xA8
        public string Version;

        // Offset 0xC4
        public int BeatmapId;

        // Offset 0xC8
        public int BeatmapSetId;

        public void Read(IntPtr baseAddress)
        {
            ArtistUnicode = MarshalReader.ReadString(baseAddress.Add(0x18));
            Artist = MarshalReader.ReadString(baseAddress.Add(0x1C));
            Tags = MarshalReader.ReadString(baseAddress.Add(0x20));
            TitleUnicode = MarshalReader.ReadString(baseAddress.Add(0x24));
            Title = MarshalReader.ReadString(baseAddress.Add(0x28));
            ArtistUnicode = MarshalReader.ReadString(baseAddress.Add(0x78));
            ArtistUnicode = MarshalReader.ReadString(baseAddress.Add(0xA4));
            ArtistUnicode = MarshalReader.ReadString(baseAddress.Add(0xA8));
            BeatmapId = MarshalReader.ReadInt32(baseAddress.Add(0xC4));
            BeatmapSetId = MarshalReader.ReadInt32(baseAddress.Add(0xC8));
        }
    }
}