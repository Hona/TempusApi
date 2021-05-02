using Newtonsoft.Json;

namespace TempusApi.Models
{
    public class AuthorModel
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }
        [JsonProperty(PropertyName = "user_name")] public string Username { get; set; }
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }
        [JsonProperty(PropertyName = "steamid")] public string SteamId { get; set; }
        [JsonProperty(PropertyName = "user_id")] public int UserId { get; set; }
        [JsonProperty(PropertyName = "map_count")] public int MapCount { get; set; }
    }
}