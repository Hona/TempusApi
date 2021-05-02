using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempusApi.Models
{
    public class SteamProfile
    {
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("personaname")] public string Nickname { get; set; }
        [JsonProperty("avatar")] public SteamAvatars Avatars { get; set; }
    }
}
