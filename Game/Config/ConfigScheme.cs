using Newtonsoft.Json;

namespace softnaosu.Game.Config
{
    public class ConfigScheme
    {
        [JsonProperty("process_name")]
        public string ProcessName = "osu!";
    }
}