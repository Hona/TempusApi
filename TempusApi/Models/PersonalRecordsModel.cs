using System.Data.Common;
using System.Text.Json.Serialization;

namespace TempusApi.Models
{
    public class PersonalRecordsModel
    {
        [JsonPropertyName("zone_info")]
        public ZoneInfo ZoneInfo { get; set; }

        [JsonPropertyName("tier_info")]
        public TierInfo Type { get; set; }

        [JsonPropertyName("completion_info")]
        public CompletionInfo CompletionInfo { get; set; }

        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }

    public class ZoneInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("map_id")]
        public int MapId { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("zoneindex")]
        public int ZoneIndex { get; set; }
        [JsonPropertyName("custom_name")]
        public string CustomName { get; set; }
    }

    public class TierInfo
    {
        [JsonPropertyName("3")]
        public int Soldier { get; set; }

        [JsonPropertyName("4")]
        public int Demoman { get; set; }
    }

    public class CompletionInfo
    {
        [JsonPropertyName("soldier")]
        public int SoldierCount { get; set; }
        [JsonPropertyName("demoman")]
        public int DemomanCount { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("zone_id")]
        public int ZoneId { get; set; }
        [JsonPropertyName("duration")]
        public double Duration { get; set; }
        [JsonPropertyName("class")]
        public int Class { get; set; }
        [JsonPropertyName("date")]
        public double Date { get; set; }
        [JsonPropertyName("demo_start_tick")]
        public ulong DemoStartTick { get; set; }
        [JsonPropertyName("demo_end_tick")]
        public ulong DemoEndTick { get; set; }
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("steamid")]
        public string SteamId { get; set; }
        [JsonPropertyName("rank")]
        public int Rank { get; set; }
        [JsonPropertyName("demo_id")]
        public int DemoId { get; set; }
        [JsonPropertyName("demo_url")]
        public string DemoUrl { get; set; }
        [JsonPropertyName("demo_server_id")]
        public int DemoServerId { get; set; }
        [JsonPropertyName("demo_server_name")]
        public string DemoServerName { get; set; }
    }
}