using System;
using System.Diagnostics;
using System.Linq;
using softnaosu.Memory;
using softnaosu.Memory.Signatures;

namespace softnaosu.Game
{
    public class GameProcess
    {
        public static bool Init()
        {
            var process = Process.GetProcessesByName(Global.Config.ProcessName).FirstOrDefault();

            if (process == default)
            {
                Console.WriteLine($"Failed to obtain process. Launch {Global.Config.ProcessName}.exe first!");

                return false;
            }

            MemoryManager.Process = process;
            
            // then scan all signatures
            if (BeatmapSignature.Scan() &&
                PlayerSignature.Scan())
            {
                // unnecessary stuff, just for test :>
                // BeatmapTest.Start();
                PlayerTest.Start();
                
                return true;
            }

            return false;
        }
    }
}