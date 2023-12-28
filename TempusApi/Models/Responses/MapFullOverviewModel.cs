using System;
using System.Collections.Generic;
using TempusApi.Enums;
using TempusApi.Models.DetailedMapList;

namespace TempusApi.Models.Responses
{
    public class MapFullOverviewModel
    {
        [JsonPropertyName("videos")] public VideosModel Videos { get; set; }

        [JsonPropertyName("tier_info")] public TierInfoModel TierInfo { get; set; }

        [JsonPropertyName("demoman_runs")] public List<RecordModel> DemomanRuns { get; set; }

        [JsonPropertyName("authors")] public List<AuthorModel> Authors { get; set; }

        [JsonPropertyName("map_info")] public MapInfoModel MapInfo { get; set; }

        [JsonPropertyName("soldier_runs")] public List<RecordModel> SoldierRuns { get; set; }

        [JsonPropertyName("zone_counts")] public ZoneCounts ZoneCounts { get; set; }

        public List<RecordModel> GetClassRuns(Class @class)
        {
            return @class switch
            {
                Class.Soldier => SoldierRuns,
                Class.Demoman => DemomanRuns,
                _ => throw new ArgumentOutOfRangeException(nameof(@class), "No such class id exists")
            };
        }
    }
}