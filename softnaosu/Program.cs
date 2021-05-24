using softnaosu.Config;
using softnaosu.Game;

namespace softnaosu
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Global.Config = new ConfigScheme();
            GameProcess.Init();
        }

        public static void Test<T, TR>() where T : new() where TR : class
        {
            
        }
    }
}