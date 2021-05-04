using softnaosu.Game.Config;

namespace softnaosu.Game
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Global.Config = ConfigManager.Read();
            
            
        }
    }
}