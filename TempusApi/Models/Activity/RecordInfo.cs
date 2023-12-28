﻿using TempusApi.Enums;

namespace TempusApi.Models.Activity
{
    public class RecordInfo
    {
        [JsonPropertyName("demo_id")] public long DemoId { get; set; }

        [JsonPropertyName("server_id")] public long ServerId { get; set; }

        [JsonPropertyName("user_id")] public long UserId { get; set; }

        [JsonPropertyName("zone_id")] public long ZoneId { get; set; }

        [JsonPropertyName("demo_start_tick")] public long DemoStartTick { get; set; }

        [JsonPropertyName("rank")] public int Rank { get; set; }

        [JsonPropertyName("class")] public Class Class { get; set; }

        [JsonPropertyName("date")] public double Date { get; set; }

        [JsonPropertyName("duration")] public double Duration { get; set; }

        [JsonPropertyName("demo_end_tick")] public int DemoEndTick { get; set; }

        [JsonPropertyName("id")] public long Id { get; set; }
    }
}