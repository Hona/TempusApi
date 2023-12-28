using System.Collections.Generic;
using TempusApi.Enums;

namespace TempusApi.Models.Responses;

public class FullMapOverview2
{
    [JsonPropertyName("map_info")] public MapInfo MapInfo { get; set; }

    [JsonPropertyName("tier_info")] public TierInfo TierInfo { get; set; }

    [JsonPropertyName("soldier_runs")] public List<SoldierRun> SoldierRuns { get; set; }

    [JsonPropertyName("demoman_runs")] public List<DemomanRun> DemomanRuns { get; set; }

    [JsonPropertyName("zone_counts")] public ZoneCounts ZoneCounts { get; set; }

    [JsonPropertyName("videos")] public Videos Videos { get; set; }

    [JsonPropertyName("authors")] public List<Author> Authors { get; set; }

    [JsonPropertyName("zones")] public Zones Zones { get; set; }
}

public class Author
{
    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("map_count")] public int MapCount { get; set; }

    [JsonPropertyName("player_info")] public PlayerInfo PlayerInfo { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }
}

public class ZoneInfo
{
    [JsonPropertyName("map_id")] public long MapId { get; set; }

    [JsonPropertyName("zoneindex")] public int Zoneindex { get; set; }

    [JsonPropertyName("custom_name")] public string CustomName { get; set; }

    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("type")] public ZoneType Type { get; set; }
}

public class DemomanRun
{
    [JsonPropertyName("steamid")] public string Steamid { get; set; }

    [JsonPropertyName("player_info")] public PlayerInfo PlayerInfo { get; set; }

    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("duration")] public double Duration { get; set; }

    [JsonPropertyName("date")] public double Date { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }
}

public class MapInfo
{
    [JsonPropertyName("date_added")] public double DateAdded { get; set; }

    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }
}

public class PlayerInfo
{
    [JsonPropertyName("steamid")] public string Steamid { get; set; }

    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }
}

public class SoldierRun
{
    [JsonPropertyName("steamid")] public string Steamid { get; set; }

    [JsonPropertyName("player_info")] public PlayerInfo PlayerInfo { get; set; }

    [JsonPropertyName("id")] public long Id { get; set; }

    [JsonPropertyName("duration")] public double Duration { get; set; }

    [JsonPropertyName("date")] public double Date { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }
}

public class TierInfo
{
    [JsonPropertyName("soldier")] public int Soldier { get; set; }

    [JsonPropertyName("demoman")] public int Demoman { get; set; }
}

public class Videos
{
    [JsonPropertyName("soldier")] public string Soldier { get; set; }

    [JsonPropertyName("demoman")] public string Demoman { get; set; }
}

public class ZoneCounts
{
    [JsonPropertyName("bonus_end")] public int BonusEnd { get; set; }

    [JsonPropertyName("bonus")] public int Bonus { get; set; }

    [JsonPropertyName("course")] public int Course { get; set; }

    [JsonPropertyName("course_end")] public int CourseEnd { get; set; }

    [JsonPropertyName("trick")] public int Trick { get; set; }

    [JsonPropertyName("map_end")] public int MapEnd { get; set; }

    [JsonPropertyName("map")] public int Map { get; set; }

    [JsonPropertyName("misc")] public int Misc { get; set; }
}

public class Zones
{
    [JsonPropertyName("bonus_end")] public List<ZoneInfo> BonusEnd { get; set; }

    [JsonPropertyName("bonus")] public List<ZoneInfo> Bonus { get; set; }

    [JsonPropertyName("course")] public List<ZoneInfo> Course { get; set; }

    [JsonPropertyName("course_end")] public List<ZoneInfo> CourseEnd { get; set; }

    [JsonPropertyName("trick")] public List<ZoneInfo> Trick { get; set; }

    [JsonPropertyName("map_end")] public List<ZoneInfo> MapEnd { get; set; }

    [JsonPropertyName("map")] public List<ZoneInfo> Map { get; set; }

    [JsonPropertyName("misc")] public List<ZoneInfo> Misc { get; set; }
}