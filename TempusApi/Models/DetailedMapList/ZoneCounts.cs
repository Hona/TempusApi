namespace TempusApi.Models.DetailedMapList
{
    public class ZoneCounts
    {
        [JsonPropertyName("checkpoint")] public int Checkpoint { get; set; }

        [JsonPropertyName("map")] public int Map { get; set; }

        [JsonPropertyName("linear")] public int Linear { get; set; }

        [JsonPropertyName("special")] public int Special { get; set; }

        [JsonPropertyName("map_end")] public int MapEnd { get; set; }

        [JsonPropertyName("course_end")] public int? CourseEnd { get; set; }

        [JsonPropertyName("bonus")] public int? Bonus { get; set; }

        [JsonPropertyName("misc")] public int? Misc { get; set; }

        [JsonPropertyName("trick")] public int? Trick { get; set; }

        [JsonPropertyName("course")] public int? Course { get; set; }

        [JsonPropertyName("bonus_end")] public int? BonusEnd { get; set; }
    }
}