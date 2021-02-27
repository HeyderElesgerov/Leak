using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Post;
using Leak.Application.ViewModels.Utility;
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

        public BlogController(IPostService postService)
        {
            _postService = postService;
        }

        [Route("~/Blog/{id}/{title}")]
        public IActionResult Index(int id, string title, int page = 1)
        {
            int elementCount = 9;
            var posts = _postService.GetPaginatedPosts(page, elementCount, p => p.BlogId == id, p => p.Category)
                                    .Select(p =>
                                        {
                                            if (p.Content.Length > 250)
                                                p.Content = p.Content.Substring(0, 250) + "...";

                                            return p;
                                        })
                                    .ToList();

            var vm = new PaginatedElementsViewModel<PostViewModel>(posts, page, elementCount);

            return View(vm);
        }
    }
}
