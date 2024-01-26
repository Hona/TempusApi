namespace TempusApi.Models.PlayerStats
{
    public class ZonedStats
    {
        [JsonPropertyName("map")] public BaseZoneStats Map { get; set; }

        [JsonPropertyName("course")] public BaseZoneStats Course { get; set; }

        [JsonPropertyName("bonus")] public BaseZoneStats Bonus { get; set; }

        [JsonPropertyName("Trick")] public BaseZoneStats Trick { get; set; }
    }
}