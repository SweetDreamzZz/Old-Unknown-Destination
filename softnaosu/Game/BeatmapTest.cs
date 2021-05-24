using System;
using System.Threading;
using softnaosu.Memory.Structures.Beatmap;

namespace softnaosu.Game
{
    public class BeatmapTest
    {
        public static void Start()
        {
            Beatmap beatmap = default;

            while (true)
            {
                var bm = Beatmap.Current;
                
                if (bm.BaseAddress != (beatmap?.BaseAddress ?? IntPtr.Zero))
                {
                    beatmap = bm;

                    Console.ForegroundColor = ConsoleColor.White;
                    
                    Console.Write($"{beatmap.MetadataSection.ArtistUnicode} - {beatmap.MetadataSection.TitleUnicode} / ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    
                    Console.WriteLine($"https://osu.ppy.sh/b/{beatmap.MetadataSection.BeatmapId}");
                    
                    Console.ResetColor();
                }
                
                Thread.Sleep(1);
            }
        }
    }
}