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
    }
}
