using System.Text.Json.Serialization;

namespace ForumFree.NET.Models
{
    public class Post
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("points")]
        private string? Points { get; set; }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("topic")]
        public Topic? Topic { get; set; }

        [JsonPropertyName("forum")]
        public Forum? Forum { get; set; }
    }
}
