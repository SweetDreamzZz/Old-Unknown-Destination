using System.Diagnostics;
using softnaosu.Config;
using softnaosu.Game.Memory;

namespace softnaosu
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Global.Config = ConfigManager.Read();
        }
    }
}