﻿using Newtonsoft.Json;

namespace TempusApi.Models.Activity
{
    public class TempusRecordBase
    {
        [JsonProperty(PropertyName = "record_info")] public RecordInfoShort RecordInfo { get; set; }

        [JsonProperty(PropertyName = "zone_info")] public ZoneInfo ZoneInfo { get; set; }

        [JsonProperty(PropertyName = "map_info")] public MapInfo MapInfo { get; set; }

        [JsonProperty(PropertyName = "player_info")] public PlayerInfo PlayerInfo { get; set; }
    }
}