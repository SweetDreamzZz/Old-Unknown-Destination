using softnaosu.Memory.Serialization;

namespace softnaosu.Memory.Structures.Beatmap.Sections
{
    public class BeatmapStructureMetadataSection : IMemoryDeserializable
    {
        [Offset(0x18)] public string ArtistUnicode;

        [Offset(0x1C)] public string Artist;

        [Offset(0x20)] public string Tags;
        
        [Offset(0x24)] public string TitleUnicode;

        [Offset(0x28)] public string Title;

        [Offset(0x78)] public string Creator;

        [Offset(0xA4)] public string Source;

        [Offset(0xA8)] public string Version;

        [Offset(0xC4)] public int BeatmapId;

        [Offset(0xC8)] public int BeatmapSetId;
        public int GetLength()
        {
            return 0xC8 + sizeof(int);
        }

        public void ReadFromStream(SerializationReader reader)
        {
            reader.ReadBytes(0x18); // skip 24 bytes
            ArtistUnicode = reader.ReadString();
            Artist = reader.ReadString();
            Tags = reader.ReadString();
            TitleUnicode = reader.ReadString();
            Title = reader.ReadString();
            reader.ReadBytes(0x78 - (0x28 + 4)); // skip idk skolko bytes
            Creator = reader.ReadString();
            reader.ReadBytes(0xA4 - (0x78 + 4)); // skip idk skolko bytes
            Source = reader.ReadString();
            Version = reader.ReadString();
            reader.ReadBytes(0xC4 - (0xA8 + 4)); // skip idk skolko bytes
            BeatmapId = reader.ReadInt32();
            BeatmapSetId = reader.ReadInt32();
        }
    }
}