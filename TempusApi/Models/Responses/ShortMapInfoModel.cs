using Newtonsoft.Json;

namespace TempusApi.Models.Responses
{
    public class ShortMapInfoModel
    {
        [JsonProperty(PropertyName = "id")] public int Id { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        public override string ToString() => Name;
    }
}