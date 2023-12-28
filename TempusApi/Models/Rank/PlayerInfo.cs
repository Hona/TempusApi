namespace TempusApi.Models.Rank
{
    public class PlayerInfo
    {
        [JsonPropertyName("steamid")] public string Steamid { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("country")] public object Country { get; set; }

        [JsonPropertyName("first_seen")] public double FirstSeen { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("last_seen")] public double? LastSeen { get; set; }

        [JsonPropertyName("country_code")] public string CountryCode { get; set; }
    }
}