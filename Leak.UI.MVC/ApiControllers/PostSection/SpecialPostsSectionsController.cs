using Leak.Application.Interfaces;
using Leak.Domain.Models;
using Leak.UI.MVC.Dtos.PostSection;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leak.UI.MVC.ApiControllers.PostSection
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialPostsSectionsController<TSection> : ControllerBase
        where TSection : SpecialPostsSection
    {
        private IPostsSectionService<TSection> _sectionService;

        protected SpecialPostsSectionsController(IPostsSectionService<TSection> sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sectionService.GetAllPosts(s => s.Post));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePostSectionDto createPost)
        {
            var result = await _sectionService.AddPostToSection(createPost.PostId);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _sectionService.RemovePostFromSection(id);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }
    }
}
