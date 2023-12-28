using System;
using System.Collections.Generic;
using TempusApi.Models.Activity;

namespace TempusApi.Models.Responses
{
    public class ZonedResults
    {
        [JsonPropertyName("soldier")] public List<RecordInfoShort> SoldierRuns { get; set; }

        [JsonPropertyName("demoman")] public List<RecordInfoShort> DemomanRuns { get; set; }

        public List<RecordInfoShort> GetClassRuns(int id)
        {
            return id switch
            {
                3 => SoldierRuns,
                4 => DemomanRuns,
                _ => throw new ArgumentOutOfRangeException("No such class id exists")
            };
        }
    }
}