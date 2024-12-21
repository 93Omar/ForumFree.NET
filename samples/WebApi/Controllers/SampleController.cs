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
            var response = await _forumFreeClient.GetPostsByUserId(userId, page);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProfileById(int userId)
        {
            var response = await _forumFreeClient.GetProfileById(userId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProfileByNickname(string nickname)
        {
            var response = await _forumFreeClient.GetProfileByNickname(nickname);
            return Ok(response);
        }
    }
}
