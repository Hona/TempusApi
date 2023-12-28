namespace TempusApi.Models.Responses
{
    public class ServerDemoModel
    {
        [JsonPropertyName("id")] public int DemoId { get; set; }

        [JsonPropertyName("mapname")] public string MapName { get; set; }

        [JsonPropertyName("filename")] public string FileName { get; set; }

        [JsonPropertyName("date")] public double Date { get; set; }

        [JsonPropertyName("url")] public string Url { get; set; }

        [JsonPropertyName("recording")] public bool Recording { get; set; }

        [JsonPropertyName("requested")] public bool Requested { get; set; }

        [JsonPropertyName("uploader_id")] public int? UploaderId { get; set; }

        [JsonPropertyName("server_id")] public int ServerId { get; set; }

        [JsonPropertyName("expired")] public bool Expired { get; set; }

        [JsonPropertyName("deleted")] public bool Deleted { get; set; }
    }
}