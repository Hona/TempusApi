namespace TempusApi.Models.Activity
{
    public class RecordInfoShort
    {
        [JsonPropertyName("name")] public string Name { get; set; }

        [JsonPropertyName("server_id")] public int ServerId { get; set; }

        [JsonPropertyName("user_id")] public int UserId { get; set; }

        [JsonPropertyName("zone_id")] public int ZoneId { get; set; }

        [JsonPropertyName("class")] public int Class { get; set; }

        [JsonPropertyName("date")] public double Date { get; set; }

        [JsonPropertyName("duration")] public double Duration { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("rank")] public int? Rank { get; set; }

        [JsonPropertyName("player_info")] public ServerPlayerModel PlayerInfo { get; set; }
    }
}