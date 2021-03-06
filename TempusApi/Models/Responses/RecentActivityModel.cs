﻿using System.Collections.Generic;
using Newtonsoft.Json;
using TempusApi.Models.Activity;

namespace TempusApi.Models.Responses
{
    public class RecentActivityModel
    {
        [JsonProperty(PropertyName = "map_tops")] public List<MapTop> MapTopTimes { get; set; }

        [JsonProperty(PropertyName = "course_wrs")] public List<CourseWr> CourseRecords { get; set; }

        [JsonProperty(PropertyName = "map_wrs")] public List<MapWr> MapRecords { get; set; }

        [JsonProperty(PropertyName = "bonus_wrs")] public List<BonusWr> BonusRecords { get; set; }
    }
}