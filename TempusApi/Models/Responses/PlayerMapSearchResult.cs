using System.Collections.Generic;
using Newtonsoft.Json;
using TempusApi.Models.Activity;

namespace TempusApi.Models.Responses
{
    public class PlayerMapSearchResult
    {
        [JsonProperty(PropertyName = "players")] public List<ServerPlayerModel> Players { get; set; }

        [JsonProperty(PropertyName = "maps")] public List<MapInfo> Maps { get; set; }
    }
}