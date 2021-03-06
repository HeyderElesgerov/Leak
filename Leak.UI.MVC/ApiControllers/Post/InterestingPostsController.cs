﻿using Leak.Application.Interfaces;
using Leak.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leak.UI.MVC.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestingPostsController : ControllerBase
    {
        private IPostsSectionService<InterestingPostSection> _interestingPostSection;

        public InterestingPostsController(IPostsSectionService<InterestingPostSection> interestingPostSection)
        {
            _interestingPostSection = interestingPostSection;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _interestingPostSection.GetAllPosts(p => p.Post.Blog));
        }
    }
}
