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
        private string? PointsRaw { get; set; }

        [JsonIgnore]
        public int Points
        {
            get
            {
                if (string.IsNullOrEmpty(PointsRaw))
                    return 0;

                _ = int.TryParse(PointsRaw, out int result);
                return result;
            }
        }

        [JsonPropertyName("content")]
        public string? Content { get; set; }

        [JsonPropertyName("topic")]
        public Topic? Topic { get; set; }

        [JsonPropertyName("forum")]
        public Forum? Forum { get; set; }
    }
}
