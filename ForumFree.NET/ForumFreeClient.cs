using ForumFree.NET.Models;
using ForumFree.NET.Pagination;
using ForumFree.NET.Utilities;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;

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

        public async Task<PaginatedPostsResponse?> GetPostsByUserId(int userId, int page)
        {
            IPaginationStrategy paginationStrategy = new FifteenMultiplePaginationStrategy();

            Dictionary<string, string?> parameters = QueryStringUtilities.CreateWithCookie();
            parameters.Add("member_posts", userId.ToString());
            parameters.Add("st", paginationStrategy.GetPageNumber(page).ToString());

            string requestUri = QueryHelpers.AddQueryString(_apiPrefix, parameters);

            PaginatedPostsResponse? response = await _httpClient.GetFromJsonAsync<PaginatedPostsResponse>(requestUri);

            return response;
        }
    }
}
