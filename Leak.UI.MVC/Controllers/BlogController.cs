using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Post;
using Leak.Application.ViewModels.Utility;
using Leak.Domain.Models;
using Leak.Domain.Repository;
using Leak.UI.MVC.Dtos.Blog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leak.UI.MVC.Controllers
{
    public class BlogController : Controller
    {
        private IPostService _postService;
        private IPostRepository _postRepository;
        private IBlogService _blogService;

        public BlogController(IPostService postService, IPostRepository postRepository, IBlogService blogService)
        {
            _postService = postService;
            _postRepository = postRepository;
            _blogService = blogService;
        }

        [Route("~/Blog/{id}/{title}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id, string title, int page = 1)
        {
            var blog = _blogService.GetById(id);

            if (blog == null)
                return NotFound();

            ViewData["BlogTitle"] = blog.Title;
            ViewData["BlogId"] = blog.Id;

            int elementCount = 9;
            var posts = _postService.GetPaginatedPosts(page, elementCount, p => p.BlogId == id && p.IsActive, p => p.Category)
                                    .Select(p =>
                                        {
                                            if (p.Content.Length > 250)
                                                p.Content = p.Content.Substring(0, 250) + "...";

                                            return p;
                                        })
                                    .ToList();

            int maxElementCount = await _postRepository.Count(p => p.BlogId == id);
            var vm = new PaginatedElementsViewModel<PostViewModel>(posts, page, elementCount, maxElementCount);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateBlogDto());
        }
    }
}
