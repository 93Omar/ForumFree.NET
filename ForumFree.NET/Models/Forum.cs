using System.Text.Json.Serialization;

namespace ForumFree.NET.Models
{
    public class Forum
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}