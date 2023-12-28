using System.Collections.Generic;

namespace TempusApi.Models.Responses
{
    public class RanksOverviewModel
    {
        [JsonPropertyName("count")] public int PlayerCount { get; set; }

        [JsonPropertyName("players")] public List<PlayerRankOverviewModel> TopPlayers { get; set; }
    }
}