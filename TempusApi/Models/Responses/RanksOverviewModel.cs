using System.Collections.Generic;
using Newtonsoft.Json;

namespace TempusApi.Models.Responses
{
    public class RanksOverviewModel
    {
        [JsonProperty(PropertyName = "count")] public int PlayerCount { get; set; }

        [JsonProperty(PropertyName = "players")] public List<PlayerRankOverviewModel> TopPlayers { get; set; }
    }
}