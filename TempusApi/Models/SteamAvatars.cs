namespace TempusApi.Models
{
    public class SteamAvatars
    {
        [JsonPropertyName("small")] public string SmallUrl { get; set; }
        [JsonPropertyName("medium")] public string MediumUrl { get; set; }
        [JsonPropertyName("large")] public string LargeUrl { get; set; }
    }
}
