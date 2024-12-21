using System.Text.Json.Serialization;

namespace ForumFree.NET.Models
{
    public class Permission
    {
        [JsonPropertyName("founder")]
        public int Founder { get; set; }

        [JsonPropertyName("admin")]
        public int Admin { get; set; }

        [JsonPropertyName("admin_sez")]
        public int AdminSez { get; set; }

        [JsonPropertyName("admin_graphic")]
        public int AdminGraphic { get; set; }

        [JsonPropertyName("admin_users")]
        public int AdminUsers { get; set; }

        [JsonPropertyName("global_mod")]
        public int GlobalMod { get; set; }

        [JsonPropertyName("mod_sez")]
        public int ModSez { get; set; }
    }
}