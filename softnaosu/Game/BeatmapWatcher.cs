using System;
using System.Threading;
using softnaosu.Memory.Structures.Beatmap;

namespace softnaosu.Game
{
    public class BeatmapWatcher
    {
        public static void Start()
        {
            BeatmapStructure beatmap = default;

            while (true)
            {
                var bm = BeatmapStructure.CurrentNew();
                
                if (bm.BaseAddress != (beatmap?.BaseAddress ?? IntPtr.Zero))
                {
                    beatmap = bm;
                    
                    Console.WriteLine($"{beatmap.MetadataSection.ArtistUnicode} - {beatmap.MetadataSection.TitleUnicode} / https://osu.ppy.sh/b/{beatmap.MetadataSection.BeatmapId}");
                }
                
                Thread.Sleep(1);
            }
        }
    }
}