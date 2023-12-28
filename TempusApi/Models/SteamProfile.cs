namespace TempusApi.Models
{
    public class SteamProfile
    {
        [JsonPropertyName("status")] public string Status { get; set; }
        [JsonPropertyName("personaname")] public string Nickname { get; set; }
        [JsonPropertyName("avatar")] public SteamAvatars Avatars { get; set; }
    }
}
