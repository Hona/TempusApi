namespace TempusApi.Models.Rank
{
    public class ClassRankInfo
    {
        [JsonPropertyName("4")] public DemoRank DemoRank { get; set; }

        [JsonPropertyName("3")] public SoldierRank SoldierRank { get; set; }
    }
}