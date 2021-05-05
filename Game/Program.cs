using System.Diagnostics;
using softnaosu.Game.Config;

namespace softnaosu.Game
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Global.Config = ConfigManager.Read();
            Global.Process = Process.GetProcessesByName(Global.Config.ProcessName)[0];
        }
    }
}