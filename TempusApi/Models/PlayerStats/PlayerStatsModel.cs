using TempusApi.Models.Rank;

namespace TempusApi.Models.PlayerStats
{
    public class PlayerStatsModel
    {
        [JsonPropertyName("player_info")] public PlayerInfo PlayerInfo { get; set; }

        [JsonPropertyName("class_rank_info")] public ClassRankInfo ClassRankInfo { get; set; }

        [JsonPropertyName("rank_info")] public RankInfo RankInfo { get; set; }

        [JsonPropertyName("country_class_rank_info")] public ClassRankInfo CountryClassRankInfo { get; set; }

        [JsonPropertyName("country_rank_info")] public BaseRank CountryOverallRankInfo { get; set; }

        [JsonPropertyName("top_stats")] public ZonedStats TopTimeStats { get; set; }

        [JsonPropertyName("pr_stats")] public ZonedStats PersonalRecordStats { get; set; }

        [JsonPropertyName("wr_stats")] public ZonedStats WorldRecordStats { get; set; }

        [JsonPropertyName("zone_count")] public ZonesCount ZonesCount { get; set; }
    }
}