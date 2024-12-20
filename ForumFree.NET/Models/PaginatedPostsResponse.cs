using Newtonsoft.Json;

namespace ForumFree.NET.Models
{
    public class PaginatedPostsResponse : BaseResponse
    {
        [JsonProperty("pages")]
        public int TotalPages { get; set; }

        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("total")]
        public int TotalPosts { get; set; }

        [JsonProperty("posts")]
        public IEnumerable<Post> Posts { get; set; }

        public PaginatedPostsResponse()
        {
            Posts = [];
        }
    }
}
