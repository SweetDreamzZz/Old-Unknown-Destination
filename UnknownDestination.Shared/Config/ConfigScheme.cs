using Newtonsoft.Json;

namespace UnknownDestination.Shared.Config
{
    public class ConfigScheme
    {
        [JsonProperty("process_name")] public string ProcessName = "osu!";
    }
}