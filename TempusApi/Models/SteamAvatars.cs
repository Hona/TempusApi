using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempusApi.Models
{
    public class SteamAvatars
    {
        [JsonProperty("small")] public string SmallUrl { get; set; }
        [JsonProperty("medium")] public string MediumUrl { get; set; }
        [JsonProperty("large")] public string LargeUrl { get; set; }
    }
}
