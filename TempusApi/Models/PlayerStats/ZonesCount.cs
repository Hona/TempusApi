namespace TempusApi.Models.PlayerStats
{
    public class ZonesCount
    {
        [JsonPropertyName("checkpoint")] public ZoneCount Checkpoint { get; set; }

        [JsonPropertyName("course_end")] public ZoneCount CourseEnd { get; set; }

        [JsonPropertyName("linear")] public ZoneCount Linear { get; set; }

        [JsonPropertyName("map")] public ZoneCount Map { get; set; }

        [JsonPropertyName("bonus")] public ZoneCount Bonus { get; set; }

        [JsonPropertyName("misc")] public ZoneCount Misc { get; set; }

        [JsonPropertyName("map_end")] public ZoneCount MapEnd { get; set; }

        [JsonPropertyName("trick")] public ZoneCount Trick { get; set; }

        [JsonPropertyName("course")] public ZoneCount Course { get; set; }

        [JsonPropertyName("bonus_end")] public ZoneCount BonusEnd { get; set; }

        [JsonPropertyName("special")] public ZoneCount Special { get; set; }
    }
}