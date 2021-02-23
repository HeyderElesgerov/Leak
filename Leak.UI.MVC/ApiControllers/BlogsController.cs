﻿using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Blog;
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

        [HttpPost]
        public async Task<IActionResult> Add(CreateBlogViewModel createBlogViewModel)
        {
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
    }
}
