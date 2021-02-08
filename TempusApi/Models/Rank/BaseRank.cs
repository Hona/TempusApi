using Newtonsoft.Json;

namespace TempusApi.Models.Rank
{
    public class BaseRank
    {
        [JsonProperty(PropertyName = "total_ranked")] public int TotalRanked { get; set; }

        [JsonProperty(PropertyName = "points")] public double Points { get; set; }

        [JsonProperty(PropertyName = "rank")] public int Rank { get; set; }

        [JsonProperty(PropertyName = "title")] public string Title { get; set; }
    }
}