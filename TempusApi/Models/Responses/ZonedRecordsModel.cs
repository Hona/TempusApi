using Newtonsoft.Json;

namespace TempusApi.Models.Responses
{
    public class ZonedRecordsModel
    {
        [JsonProperty(PropertyName = "tier_info")] public TierInfoModel TierInfo { get; set; }

        [JsonProperty(PropertyName = "zone_info")] public RecordZoneInfo RecordZoneInfo { get; set; }

        [JsonProperty(PropertyName = "results")] public ZonedResults Runs { get; set; }
    }
}