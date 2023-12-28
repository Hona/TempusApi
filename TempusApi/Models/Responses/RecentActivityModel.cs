using System.Collections.Generic;
using TempusApi.Models.Activity;

namespace TempusApi.Models.Responses
{
    public class RecentActivityModel
    {
        [JsonPropertyName("map_tops")] public List<MapTop> MapTopTimes { get; set; }

        [JsonPropertyName("course_wrs")] public List<CourseWr> CourseRecords { get; set; }

        [JsonPropertyName("map_wrs")] public List<MapWr> MapRecords { get; set; }

        [JsonPropertyName("bonus_wrs")] public List<BonusWr> BonusRecords { get; set; }
    }
}