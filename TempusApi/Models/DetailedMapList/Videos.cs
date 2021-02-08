using Newtonsoft.Json;

namespace TempusApi.Models.DetailedMapList
{
    public class Videos
    {
        [JsonProperty(PropertyName = "soldier")] public string Soldier { get; set; }

        [JsonProperty(PropertyName = "demoman")] public string Demoman { get; set; }
    }
}