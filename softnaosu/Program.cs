using softnaosu.Config;

namespace softnaosu
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Global.Config = new ConfigScheme();
        }
    }
}