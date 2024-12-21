using ForumFree.NET;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SampleController : ControllerBase
    {
        private readonly ForumFreeClient _forumFreeClient;

        public SampleController(ForumFreeClient forumFreeClient)
        {
            _forumFreeClient = forumFreeClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetPostsByUserId(int userId, int page)
        {
            var response = await _forumFreeClient.GetPostsByUserIdAsync(userId, page);
            string rawResponse = await response.Content.ReadAsStringAsync();

            return Ok(rawResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetProfileById(int userId)
        {
            var response = await _forumFreeClient.GetProfileByIdAsync(userId);
            string rawResponse = await response.Content.ReadAsStringAsync();

            return Ok(rawResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetProfileByNickname(string nickname)
        {
            var response = await _forumFreeClient.GetProfileByNicknameAsync(nickname);
            string rawResponse = await response.Content.ReadAsStringAsync();

            return Ok(rawResponse);
        }
    }
}
