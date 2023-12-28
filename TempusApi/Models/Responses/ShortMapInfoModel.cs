namespace TempusApi.Models.Responses
{
    public class ShortMapInfoModel
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }

        public override string ToString() => Name;
    }
}