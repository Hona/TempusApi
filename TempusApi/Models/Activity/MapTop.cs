namespace TempusApi.Models.Activity
{
    public class MapTop : TempusRecordBase
    {
        [JsonPropertyName("rank")] public int Rank { get; set; }
    }
}