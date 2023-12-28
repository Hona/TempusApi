namespace TempusApi.Models
{
    public class AuthorModel
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("user_name")] public string Username { get; set; }
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("steamid")] public string SteamId { get; set; }
        [JsonPropertyName("user_id")] public long UserId { get; set; }
        [JsonPropertyName("map_count")] public int MapCount { get; set; }
    }
}