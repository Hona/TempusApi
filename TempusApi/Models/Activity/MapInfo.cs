namespace TempusApi.Models.Activity
{
    public class MapInfo
    {
        [JsonPropertyName("date_added")] public double? DateAdded { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }
    }
}