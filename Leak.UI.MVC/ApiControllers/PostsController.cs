using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leak.UI.MVC.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePostViewModel createPostViewModel)
        {
            var result = await _postService.Add(createPostViewModel);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePostViewModel updatePostViewModel)
        {
            var result = await _postService.Update(updatePostViewModel);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.Delete(id);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }
    }
}
