namespace TempusApi.Models.Rank
{
    public class RankInfo
    {
        [JsonPropertyName("total_ranked")] public long TotalRanked { get; set; }

        [JsonPropertyName("points")] public double Points { get; set; }

        [JsonPropertyName("rank")] public long Rank { get; set; }
    }
}