namespace TempusApi.Models.PlayerStats
{
    public class BaseZoneStats
    {
        [JsonPropertyName("count")] public int Count { get; set; }

        [JsonPropertyName("points")] public double Points { get; set; }
    }
}