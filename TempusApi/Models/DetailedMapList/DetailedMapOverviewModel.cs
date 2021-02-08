using System.Collections.Generic;
using Newtonsoft.Json;

namespace TempusApi.Models.DetailedMapList
{
    public class DetailedMapOverviewModel
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "videos")] public Videos Videos { get; set; }

        [JsonProperty(PropertyName = "tier_info")] public TierInfo TierInfo { get; set; }

        [JsonProperty(PropertyName = "zone_counts")] public ZoneCounts ZoneCounts { get; set; }

        [JsonProperty(PropertyName = "authors")] public List<Author> Authors { get; set; }

        [JsonProperty(PropertyName = "id")] public int Id { get; set; }

        public char IntendedClass { get; set; }
    }
}