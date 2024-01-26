namespace TempusApi.Models.Rank
{
    public class Rank
    {
        [JsonPropertyName("player_info")] public PlayerInfo PlayerInfo { get; set; }

        [JsonPropertyName("class_rank_info")] public ClassRankInfo ClassRankInfo { get; set; }

        [JsonPropertyName("rank_info")] public RankInfo RankInfo { get; set; }
    }
}