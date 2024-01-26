namespace TempusApi.Models
{
    public class ServerPlayerModel
    {
        [JsonPropertyName("steamid")] public string SteamId { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("id")] public long? Id { get; set; }
    }
}