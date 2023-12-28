namespace TempusApi.Models.Activity
{
    public class RecordInfo
    {
        [JsonPropertyName("demo_id")] public int DemoId { get; set; }

        [JsonPropertyName("server_id")] public int ServerId { get; set; }

        [JsonPropertyName("user_id")] public int UserId { get; set; }

        [JsonPropertyName("zone_id")] public int ZoneId { get; set; }

        [JsonPropertyName("demo_start_tick")] public int DemoStartTick { get; set; }

        [JsonPropertyName("rank")] public int Rank { get; set; }

        [JsonPropertyName("class")] public int Class { get; set; }

        [JsonPropertyName("date")] public double Date { get; set; }

        [JsonPropertyName("duration")] public double Duration { get; set; }

        [JsonPropertyName("demo_end_tick")] public int DemoEndTick { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }
    }
}