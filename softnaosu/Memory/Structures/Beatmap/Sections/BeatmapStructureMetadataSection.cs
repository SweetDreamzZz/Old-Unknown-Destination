namespace softnaosu.Memory.Structures.Beatmap.Sections
{
    public class BeatmapStructureMetadataSection
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
    }
}