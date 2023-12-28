using System.Collections.Generic;

namespace TempusApi.Models
{
    public class GameInfo
    {
        [JsonPropertyName("gameVersion")] public int GameVersion { get; set; }

        [JsonPropertyName("hostname")] public string Hostname { get; set; }

        [JsonPropertyName("users")] public List<ServerPlayerModel> Users { get; set; }

        [JsonPropertyName("playerCount")] public int PlayerCount { get; set; }

        [JsonPropertyName("tempusVersion")] public int TempusVersion { get; set; }

        [JsonPropertyName("spVersion")] public int SpVersion { get; set; }

        [JsonPropertyName("freeDisk")] public int? FreeDisk { get; set; }

        [JsonPropertyName("maxPlayers")] public int MaxPlayers { get; set; }

        [JsonPropertyName("appID")] public int AppId { get; set; }

        [JsonPropertyName("nextMap")] public object NextMap { get; set; }

        [JsonPropertyName("currentMap")] public string CurrentMap { get; set; }
    }
}