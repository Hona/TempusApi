﻿namespace TempusApi.Models.Responses
{
    public class RecordZoneInfo
    {
        [JsonPropertyName("id")] public long Id { get; set; }

        [JsonPropertyName("map_id")] public long MapId { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("zoneindex")] public int ZoneIndex { get; set; }

        [JsonPropertyName("index")]
        private int Index
        {
            set => ZoneIndex = value;
        }

        [JsonPropertyName("custom_name")] public string CustomName { get; set; }
    }
}