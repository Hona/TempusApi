using TempusApi.Enums;

namespace TempusApi.Models.Responses
{
    public class DemoRecordModel
    {
        [JsonPropertyName("demo_id")] public long DemoId { get; set; }

        [JsonPropertyName("server_id")] public long ServerId { get; set; }

        [JsonPropertyName("player_class")] public Class PlayerClass { get; set; }

        [JsonPropertyName("start_tick")] public long StartTick { get; set; }

        [JsonPropertyName("end_tick")] public long EndTick { get; set; }

        [JsonPropertyName("date")] public double Date { get; set; }

        [JsonPropertyName("duration")] public double Duration { get; set; }

        [JsonPropertyName("id")] public long Id { get; set; }
    }
}