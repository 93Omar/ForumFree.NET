using ForumFree.NET.Pagination;
using Microsoft.AspNetCore.WebUtilities;

namespace ForumFree.NET
{
    public class ForumFreeClient
    {
        private readonly string _apiPrefix = "api.php";

        private readonly HttpClient _httpClient;

        public ForumFreeClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task GetPostsByUserId(int userId, int page)
        {
            IPaginationStrategy paginationStrategy = new FifteenMultiplePaginationStrategy();

            Dictionary<string, string?> parameters = new()
            {
                { "member_posts", userId.ToString() },
                { "st", paginationStrategy.GetPageNumber(page).ToString() }
            };

            string requestUri = QueryHelpers.AddQueryString(_apiPrefix, parameters);

            await _httpClient.GetAsync(requestUri);
        }
    }
}
