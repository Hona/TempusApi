using System;
using System.Collections.Generic;
using TempusApi.Enums;
using TempusApi.Models.Activity;

namespace TempusApi.Models.Responses
{
    public class ZonedResults
    {
        [JsonPropertyName("soldier")] public List<RecordInfoShort> SoldierRuns { get; set; }

        [JsonPropertyName("demoman")] public List<RecordInfoShort> DemomanRuns { get; set; }

        public List<RecordInfoShort> GetClassRuns(Class @class)
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