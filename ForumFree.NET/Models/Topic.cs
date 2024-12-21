using System.Text.Json.Serialization;

namespace ForumFree.NET.Models
{
    public class Topic
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("posts")]
        public int Posts { get; set; }
    }
}