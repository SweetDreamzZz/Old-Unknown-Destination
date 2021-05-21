using softnaosu.Config;
using softnaosu.Game;

namespace softnaosu
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Global.Config = new ConfigScheme();
            
            var init = GameProcess.Init();
        }
    }
}