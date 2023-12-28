namespace TempusApi.Models.Activity
{
    public class PlayerInfo
    {
        [JsonPropertyName("steamid")] public string Steamid { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }
    }
}