using System;
using UnknownDestination.Memory.Signatures;

namespace UnknownDestination.Osu
{
    public class OsuManager
    {
        public static bool Start()
        {
            Console.WriteLine("Scanning signatures...");
            if (Signatures.Beatmap.Scan())
            {
                // do something
            }
            
            return false;
        }
        
    }
}