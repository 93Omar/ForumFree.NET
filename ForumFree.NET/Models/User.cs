using System.Text.Json.Serialization;

namespace ForumFree.NET.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nickname")]
        public string? Nickname { get; set; }

        [JsonPropertyName("avatar")]
        public Uri? Avatar { get; set; }

        [JsonPropertyName("group")]
        public Group? Group { get; set; }

        [JsonPropertyName("banned")]
        public int Banned { get; set; }

        [JsonPropertyName("registration")]
        public DateTime Registration { get; set; }

        [JsonPropertyName("messages")]
        public int Messages { get; set; }

        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        [JsonPropertyName("language")]
        public string? Language { get; set; }

        [JsonPropertyName("circuito")]
        public string? Circuito { get; set; }

        [JsonPropertyName("lastVisit")]
        public string? LastVisit { get; set; }

        [JsonPropertyName("lastActivity")]
        public string? LastActivity { get; set; }

        [JsonPropertyName("view_img")]
        public string? ViewImg { get; set; }

        [JsonPropertyName("view_avs")]
        public string? ViewAvs { get; set; }

        [JsonPropertyName("enable_subs")]
        public string? EnableSubs { get; set; }

        [JsonPropertyName("enable_sign")]
        public string? EnableSign { get; set; }

        [JsonPropertyName("easyscript")]
        public string? Easyscript { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("permission")]
        public Permission? Permission { get; set; }
    }
}
