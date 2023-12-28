namespace TempusApi.Models
{
    public class ServerInfo
    {
        [JsonPropertyName("hidden")] public bool Hidden { get; set; }

        [JsonPropertyName("addr")] public string Addr { get; set; }

        [JsonPropertyName("country")] public string Country { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("shortname")] public string Shortname { get; set; }

        [JsonPropertyName("port")] public int Port { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }
    }
}