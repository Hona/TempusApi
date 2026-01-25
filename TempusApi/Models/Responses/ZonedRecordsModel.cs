namespace TempusApi.Models.Responses
{
    public class ZonedRecordsModel
    {
        [JsonPropertyName("tier_info")] public TierInfoModel TierInfo { get; set; }

        [JsonPropertyName("zone_info")] public RecordZoneInfo RecordZoneInfo { get; set; }

        [JsonPropertyName("results")] public ZonedResults Runs { get; set; }
        
        [JsonPropertyName("completion_info")] public CompletionInfo CompletionInfo { get; set; }
    }
}