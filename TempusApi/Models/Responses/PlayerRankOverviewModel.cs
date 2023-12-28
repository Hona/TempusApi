namespace TempusApi.Models.Responses
{
    public class PlayerRankOverviewModel
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("steamid")] public string SteamId { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("points")] public double Points { get; set; }

        [JsonPropertyName("rank")] public int Rank { get; set; }
    }
}