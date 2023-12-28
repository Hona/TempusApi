namespace TempusApi.Models.DetailedMapList
{
    public class Author
    {
        [JsonPropertyName("map_id")] public long MapId { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("id")] public long Id { get; set; }
    }
}