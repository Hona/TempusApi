using TempusApi.Enums;

namespace TempusApi.Models.Activity
{
    public class ZoneInfo
    {
        [JsonPropertyName("type")] public ZoneType Type { get; set; }

        [JsonPropertyName("map_id")] public long MapId { get; set; }

        [JsonPropertyName("id")] public long Id { get; set; }

        [JsonPropertyName("custom_name")] public string CustomName { get; set; }

        [JsonPropertyName("zoneindex")] public int Zoneindex { get; set; }
    }
}