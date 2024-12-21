namespace ForumFree.NET.Utilities
{
    internal static class QueryStringUtilities
    {
        public static Dictionary<string, string?> CreateWithCookie()
        {
            return new Dictionary<string, string?>()
            {
                { "cookie", "1" }
            };
        }
    }
}
