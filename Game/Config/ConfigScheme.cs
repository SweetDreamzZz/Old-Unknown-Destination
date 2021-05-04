using Newtonsoft.Json;

namespace softnaosu.Config
{
    public class ConfigScheme
    {
        [JsonProperty("process_name")]
        public string ProcessName = "osu!";
    }
}