namespace TempusApi.Enums;

public enum ZoneType
{
    Map,
    [JsonPropertyName("map_end")]
    MapEnd,
    Course,
    [JsonPropertyName("course_end")]
    CourseEnd,
    Bonus,
    [JsonPropertyName("bonus_end")]
    BonusEnd,
    Trick,
    Misc,
    Checkpoint,
    Linear
}