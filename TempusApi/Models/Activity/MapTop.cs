using Newtonsoft.Json;

namespace TempusApi.Models.Activity
{
    public class MapTop : TempusRecordBase
    {
        [JsonProperty(PropertyName = "rank")] public int Rank { get; set; }
    }
}