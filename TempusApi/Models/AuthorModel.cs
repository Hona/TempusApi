using Newtonsoft.Json;

namespace TempusApi.Models
{
    public class AuthorModel
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "id")] public int Id { get; set; }
    }
}