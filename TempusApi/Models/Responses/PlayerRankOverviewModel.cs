﻿using Newtonsoft.Json;

namespace TempusApi.Models.Responses
{
    public class PlayerRankOverviewModel
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }

        [JsonProperty(PropertyName = "steamid")] public string SteamId { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "points")] public double Points { get; set; }

        [JsonProperty(PropertyName = "rank")] public int Rank { get; set; }
    }
}