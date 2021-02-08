using Newtonsoft.Json;

namespace TempusApi.Models.DetailedMapList
{
    public class TierInfo
    {
        [JsonProperty(PropertyName = "3")] public int Soldier { get; set; }

        [JsonProperty(PropertyName = "4")] public int Demoman { get; set; }
    }
}