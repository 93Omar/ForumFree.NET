using System.Text.Json.Serialization;

namespace ForumFree.NET.Models
{
    public class Group
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("class")]
        public string? Class { get; set; }

        [JsonPropertyName("bodyclass")]
        public string? BodyClass { get; set; }
    }
}