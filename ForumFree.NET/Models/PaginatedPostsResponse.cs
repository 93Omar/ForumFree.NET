using System.Text.Json.Serialization;

namespace ForumFree.NET.Models
{
    public class PaginatedPostsResponse : BaseResponse
    {
        [JsonPropertyName("pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("total")]
        public int TotalPosts { get; set; }

        [JsonPropertyName("posts")]
        public IEnumerable<Post> Posts { get; set; }

        public PaginatedPostsResponse()
        {
            Posts = [];
        }
    }
}
