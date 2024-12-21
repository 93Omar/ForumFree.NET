namespace ForumFree.NET.Models
{
    public class ProfileResponse : BaseResponse
    {
        public Dictionary<string, User?> Users { get; set; }

        public ProfileResponse()
        {
            Users = [];
        }
    }
}
