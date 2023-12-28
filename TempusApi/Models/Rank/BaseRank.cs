namespace TempusApi.Models.Rank
{
    public class BaseRank
    {
        [JsonPropertyName("total_ranked")] public int TotalRanked { get; set; }

        [JsonPropertyName("points")] public double Points { get; set; }

        [JsonPropertyName("rank")] public int Rank { get; set; }

        [JsonPropertyName("title")] public string Title { get; set; }
    }
}