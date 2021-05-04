using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using softnaosu.Config;
using softnaosu.Game.Memory;
using softnaosu.Structures;

namespace softnaosu
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Global.Config = ConfigManager.Read();

            var asd = new Beatmap(IntPtr.Zero);
            var att = (OffsetAttribute) typeof(Beatmap).GetField("TitleUnicode").GetCustomAttributes(typeof(OffsetAttribute)).ElementAt(0);

            Console.WriteLine($"0x{(int)att.Offset:x2}");
        }
    }
}