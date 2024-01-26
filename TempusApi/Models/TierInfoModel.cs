namespace TempusApi.Models
{
    public class TierInfoModel
    {
        [JsonPropertyName("demoman")] public int Demoman { get; set; }

        [JsonPropertyName("soldier")] public int Soldier { get; set; }
    }
}