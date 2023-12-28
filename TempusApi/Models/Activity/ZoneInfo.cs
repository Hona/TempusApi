namespace TempusApi.Models.Activity
{
    public class ZoneInfo
    {
        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("map_id")] public int MapId { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("custom_name")] public object CustomName { get; set; }

        [JsonPropertyName("zoneindex")] public int Zoneindex { get; set; }
    }
}