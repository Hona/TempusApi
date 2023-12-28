using System.Collections.Generic;

namespace TempusApi.Models.DetailedMapList
{
    public class DetailedMapOverviewModel
    {
        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("videos")] public Videos Videos { get; set; }

        [JsonPropertyName("tier_info")] public TierInfo TierInfo { get; set; }

        [JsonPropertyName("zone_counts")] public ZoneCounts ZoneCounts { get; set; }

        [JsonPropertyName("authors")] public List<Author> Authors { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }

        public char IntendedClass { get; set; }
    }
}