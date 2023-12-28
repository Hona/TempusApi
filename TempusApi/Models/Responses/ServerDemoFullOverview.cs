using System.Collections.Generic;

namespace TempusApi.Models.Responses
{
    public class ServerDemoFullOverview
    {
        [JsonPropertyName("server_info")] public ServerInfo ServerInfo { get; set; }

        [JsonPropertyName("demo_info")] public ServerDemoModel Overview { get; set; }

        [JsonPropertyName("demo_runs")] public List<DemoRunModel> Runs { get; set; }
    }
}