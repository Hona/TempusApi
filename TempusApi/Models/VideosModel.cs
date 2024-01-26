namespace TempusApi.Models
{
    public class VideosModel
    {
        [JsonPropertyName("soldier")] public string Soldier { get; set; }

        [JsonPropertyName("demoman")] public string Demoman { get; set; }
    }
}