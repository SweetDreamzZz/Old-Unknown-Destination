using System.IO;
using Newtonsoft.Json;

namespace UnknownDestination.Shared.Config
{
    public class ConfigManager
    {
        private const string FileName = "config.json";

        public static ConfigScheme Read()
        {
            var config = File.Exists(FileName)
                ? JsonConvert.DeserializeObject<ConfigScheme>(File.ReadAllText(FileName))
                : new ConfigScheme();
            
            File.WriteAllText(FileName, JsonConvert.SerializeObject(config, Formatting.Indented));
            
            return config;
        }
    }
}