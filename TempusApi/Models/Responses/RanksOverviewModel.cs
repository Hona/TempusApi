using System.Collections.Generic;

namespace TempusApi.Models.Responses
{
    public class RanksOverviewModel
    {
        [JsonPropertyName("count")] public long PlayerCount { get; set; }

        [JsonPropertyName("players")] public List<PlayerRankOverviewModel> TopPlayers { get; set; }
    }
}