namespace TempusApi.Models.Responses
{
    public class ServerStatusModel
    {
        [JsonPropertyName("game_info")] public GameInfo GameInfo { get; set; }

        [JsonPropertyName("server_info")] public ServerInfo ServerInfo { get; set; }

        public override string ToString() => ServerInfo.Name;
    }
}