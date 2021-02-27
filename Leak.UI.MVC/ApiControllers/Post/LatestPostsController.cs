using Leak.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Leak.UI.MVC.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatestPostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public LatestPostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("{count}")]
        public IActionResult GetLatestPosts(int count)
        {
            return Ok(_postService.GetLatestPosts(count, p => p.Blog, p => p.Category));
        }
    }
}
