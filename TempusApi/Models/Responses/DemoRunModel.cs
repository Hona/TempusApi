namespace TempusApi.Models.Responses
{
    public class DemoRunModel
    {
        [JsonPropertyName("player_info")] public ServerPlayerModel PlayerInfo { get; set; }

        [JsonPropertyName("run_type")] public string RunType { get; set; }

        [JsonPropertyName("zone_info")] public RecordZoneInfo RecordZoneInfo { get; set; }

        [JsonPropertyName("zone_run_info")] public DemoRecordModel RunInfo { get; set; }
    }
}