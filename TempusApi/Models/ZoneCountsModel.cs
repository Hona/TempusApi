namespace TempusApi.Models
{
    public class ZoneCountsModel
    {
        [JsonPropertyName("map")] public int Map { get; set; }

        [JsonPropertyName("linear")] public int Linear { get; set; }

        [JsonPropertyName("bonus")] public int Bonus { get; set; }

        [JsonPropertyName("map_end")] public int MapEnd { get; set; }

        [JsonPropertyName("checkpoint")] public int Checkpoint { get; set; }

        [JsonPropertyName("bonus_end")] public int BonusEnd { get; set; }
    }
}