using ForumFree.NET.Pagination;
using ForumFree.NET.Utilities;
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

        public async Task<HttpResponseMessage> GetPostsByUserIdAsync(int userId, int page)
        {
            IPaginationStrategy paginationStrategy = new FifteenMultiplePaginationStrategy();

            Dictionary<string, string?> parameters = QueryStringUtilities.CreateWithCookie();
            parameters.Add("member_posts", userId.ToString());
            parameters.Add("st", paginationStrategy.GetPageNumber(page).ToString());

            string requestUri = QueryHelpers.AddQueryString(_apiPrefix, parameters);

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<HttpResponseMessage> GetProfileByIdAsync(int userId)
        {
            Dictionary<string, string?> parameters = QueryStringUtilities.CreateWithCookie();
            parameters.Add("mid", userId.ToString());

            string requestUri = QueryHelpers.AddQueryString(_apiPrefix, parameters);

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<HttpResponseMessage> GetProfileByNicknameAsync(string nickname)
        {
            Dictionary<string, string?> parameters = QueryStringUtilities.CreateWithCookie();
            parameters.Add("nick", nickname);

            string requestUri = QueryHelpers.AddQueryString(_apiPrefix, parameters);

            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();

            return response;
        }
    }
}
