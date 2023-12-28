using System.Collections.Generic;
using TempusApi.Enums;

namespace TempusApi.Models.Responses;

public class WorldRecordsData
{
    [JsonPropertyName("soldier")] public Soldier Soldier { get; set; }

    [JsonPropertyName("demoman")] public Demoman Demoman { get; set; }
}

public class DemoInfo
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("start_tick")] public ulong StartTick { get; set; }

    [JsonPropertyName("end_tick")] public ulong EndTick { get; set; }

    [JsonPropertyName("url")] public string Url { get; set; }

    [JsonPropertyName("server_info")] public ServerInfo ServerInfo { get; set; }
}

public class Demoman
{
    [JsonPropertyName("wr")] public Wr Wr { get; set; }

    [JsonPropertyName("rank2")] public Rank2 Rank2 { get; set; }
}

public class ServerInfo
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }
}

public class Soldier
{
    [JsonPropertyName("wr")] public Wr Wr { get; set; }

    [JsonPropertyName("rank2")] public Rank2 Rank2 { get; set; }
}

public class Split
{
    [JsonPropertyName("type")] public ZoneType Type { get; set; }

    [JsonPropertyName("zoneindex")] public int Zoneindex { get; set; }

    [JsonPropertyName("custom_name")] public object CustomName { get; set; }

    [JsonPropertyName("duration")] public double Duration { get; set; }

    [JsonPropertyName("compared_duration")]
    public double ComparedDuration { get; set; }
}

public class BaseRecord
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("zone_id")] public long ZoneId { get; set; }
    [JsonPropertyName("duration")] public double Duration { get; set; }
    [JsonPropertyName("class")] public Class Class { get; set; } 
    [JsonPropertyName("date")] public double Date { get; set; }
    [JsonPropertyName("demo_info")] public DemoInfo DemoInfo { get; set; }
    [JsonPropertyName("user_id")] public long UserId { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("steamid")] public string Steamid { get; set; }
    [JsonPropertyName("rank")] public long Rank { get; set; }
    [JsonPropertyName("player_info")] public PlayerInfo PlayerInfo { get; set; }
}

public class Wr : BaseRecord
{
    [JsonPropertyName("splits")] public List<Split> Splits { get; set; }
}

public class Rank2 : BaseRecord;