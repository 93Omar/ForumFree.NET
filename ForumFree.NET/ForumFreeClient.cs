using ForumFree.NET.Models;
using ForumFree.NET.Pagination;
using ForumFree.NET.Utilities;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

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

        public async Task<ProfileResponse?> GetProfileById(int userId)
        {
            Dictionary<string, string?> parameters = QueryStringUtilities.CreateWithCookie();
            parameters.Add("mid", userId.ToString());

            string requestUri = QueryHelpers.AddQueryString(_apiPrefix, parameters);

            HttpResponseMessage? responseMessage = await _httpClient.GetAsync(requestUri);
            string rawResponse = await responseMessage.Content.ReadAsStringAsync();

            ProfileResponse? response = MapProfileResponse(rawResponse, $"m{userId}");

            return response;
        }

        public async Task<ProfileResponse?> GetProfileByNickname(string nickname)
        {
            Dictionary<string, string?> parameters = QueryStringUtilities.CreateWithCookie();
            parameters.Add("nick", nickname);

            string requestUri = QueryHelpers.AddQueryString(_apiPrefix, parameters);

            HttpResponseMessage? responseMessage = await _httpClient.GetAsync(requestUri);
            string rawResponse = await responseMessage.Content.ReadAsStringAsync();

            ProfileResponse? response = MapProfileResponse(rawResponse, nickname);

            return response;
        }

        private ProfileResponse? MapProfileResponse(string rawJson, string userNodeName)
        {
            JsonObject? jsonObject = JsonSerializer.Deserialize<JsonObject>(rawJson);
            if (jsonObject is null)
                return null;

            ProfileResponse? response = JsonSerializer.Deserialize<ProfileResponse>(rawJson);

            if (response is null)
                return null;

            User? user = MapUser(jsonObject, userNodeName);
            response.Users.Add(userNodeName, user);

            return response;
        }

        private User? MapUser(JsonObject userObject, string userNodeName)
        {
            JsonNode? userInfoNode = userObject[userNodeName];

            if (userInfoNode is null)
                return null;

            User? user = userInfoNode.Deserialize<User>();

            return user;
        }
    }
}
