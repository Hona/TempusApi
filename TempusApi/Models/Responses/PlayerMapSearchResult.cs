using System.Collections.Generic;
using TempusApi.Models.Activity;

namespace TempusApi.Models.Responses
{
    public class PlayerMapSearchResult
    {
        [JsonPropertyName("players")] public List<ServerPlayerModel> Players { get; set; }

        [JsonPropertyName("maps")] public List<MapInfo> Maps { get; set; }
    }
}