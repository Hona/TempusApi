using TempusApi.Models.Activity;

namespace TempusApi.Models.Responses
{
    public class RunInfoModel
    {
        [JsonPropertyName("record_info")] public RecordInfo RecordInfo { get; set; }

        [JsonPropertyName("demo_info")] public ServerDemoModel DemoInfo { get; set; }

        [JsonPropertyName("player_info")] public ServerPlayerModel Player { get; set; }

        [JsonPropertyName("tier_info")] public TierInfoModel TierInfo { get; set; }

        [JsonPropertyName("zone_info")] public RecordZoneInfo RecordZoneInfo { get; set; }

        [JsonPropertyName("map_info")] public MapInfoModel MapInfo { get; set; }
    }
}