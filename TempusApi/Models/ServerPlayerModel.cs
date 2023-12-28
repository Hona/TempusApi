namespace TempusApi.Models
{
    public class ServerPlayerModel
    {
        [JsonPropertyName("steamid")] public string SteamId { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("id")] public int? Id { get; set; }
    }
}