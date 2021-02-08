using Newtonsoft.Json;

namespace TempusApi.Models.PlayerStats
{
    public class ZoneCount
    {
        [JsonProperty(PropertyName = "count")] public long Count { get; set; }
    }
}