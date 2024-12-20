using Newtonsoft.Json;

namespace ForumFree.NET.Models
{
    public class BaseResponse
    {
        [JsonProperty("idForum")]
        public int ForumId { get; set; }
    }
}
