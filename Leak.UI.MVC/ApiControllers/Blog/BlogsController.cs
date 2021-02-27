using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Blog;
using Leak.UI.MVC.Dtos.Blog;
using Leak.UI.MVC.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leak.UI.MVC.ApiControllers
{
    [ApiController]
    [Route("/api/blogs")]
    public class BlogsController : ControllerBase
    {
        private IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IEnumerable<BlogViewModel>> Get()
        {
            return await _blogService.GetAll();
        }

        [HttpGet("{id}")]
        public BlogViewModel Get(int id)
        {
            return _blogService.GetById(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlogDto createBlogDto)
        {
            var createBlogViewModel = CustomMapper.GetCreateBlogViewModel(createBlogDto);

            var validationResult = await _blogService.Add(createBlogViewModel);

            if (validationResult.IsValid)
                return Ok();

            return BadRequest(validationResult.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var validationResult = await _blogService.Delete(id);

            if (validationResult.IsValid)
                return Ok();

            return BadRequest(validationResult.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
        {
            var updateBlogVM = CustomMapper.GetUpdateBlogViewModel(updateBlogDto);

            var validationResult = await _blogService.Update(updateBlogVM);

            if (validationResult.IsValid)
                return Ok();

            return BadRequest(validationResult.Errors);
        }
    }
}
