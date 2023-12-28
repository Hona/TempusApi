namespace TempusApi.Models
{
    public class RecordModel
    {
        [JsonPropertyName("id")] public long Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("steamid")] public string SteamId { get; set; }

        [JsonPropertyName("duration")] public double Duration { get; set; }
    }
}