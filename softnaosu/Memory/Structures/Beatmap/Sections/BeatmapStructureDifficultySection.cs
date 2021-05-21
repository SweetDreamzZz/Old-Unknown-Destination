namespace softnaosu.Memory.Structures.Beatmap.Sections
{
    public class BeatmapStructureDifficultySection
    {
        [Offset(0x8)] public double SliderMultiplier;

        [Offset(0x10)] public double SliderTickRate;

        [Offset(0x2C)] public float ApproachRate;

        [Offset(0x30)] public float CircleSize;

        [Offset(0x34)] public float HpDrainRate;

        [Offset(0x38)] public float OverallDifficulty;
    }
}