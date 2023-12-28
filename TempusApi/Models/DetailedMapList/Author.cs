namespace TempusApi.Models.DetailedMapList
{
    public class Author
    {
        [JsonPropertyName("map_id")] public int MapId { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }
    }
}