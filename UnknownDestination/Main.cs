using System.Diagnostics;
using System.Linq;
using UnknownDestination.Osu;
using UnknownDestination.Shared;
using UnknownDestination.Shared.Config;

namespace UnknownDestination
{
    public static class Main
    {
        public static int EntryPoint(string pwzArgument)
        {
            Global.Config = new ConfigScheme();
            Global.Process = Process.GetProcessesByName(Global.Config.ProcessName).FirstOrDefault();
            
            OsuManager.Start();

            return 0;
        }
    }
}