using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace softnaosu.Config
{
    public class ConfigManager
    {
        private const string FileName = "config.json";

        public static ConfigScheme Read()
        {
            ConfigScheme config;

            if (!File.Exists(FileName))
            {
                config = new ConfigScheme();
                File.WriteAllText(FileName, JsonConvert.SerializeObject(config, Formatting.Indented));
            }
            else
            {
                var file = File.ReadAllText(FileName);
                config = JsonConvert.DeserializeObject<ConfigScheme>(file);
                File.WriteAllText(FileName, JsonConvert.SerializeObject(config, Formatting.Indented));
            }

            return config;
        }
    }
}