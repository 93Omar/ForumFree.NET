using System.Text.Json.Serialization;

namespace ForumFree.NET.Models
{
    public class BaseResponse
    {
        [JsonPropertyName("idForum")]
        public int ForumId { get; set; }
    }
}
