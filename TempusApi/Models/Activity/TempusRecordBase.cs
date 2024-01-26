namespace TempusApi.Models.Activity
{
    public class TempusRecordBase
    {
        [JsonPropertyName("record_info")] public RecordInfoShort RecordInfo { get; set; }

        [JsonPropertyName("zone_info")] public ZoneInfo ZoneInfo { get; set; }

        [JsonPropertyName("map_info")] public MapInfo MapInfo { get; set; }

        [JsonPropertyName("player_info")] public PlayerInfo PlayerInfo { get; set; }
    }
}