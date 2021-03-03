using Leak.Application.Interfaces;
using Leak.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Leak.UI.MVC.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrendPostsController : ControllerBase
    {
        private IPostsSectionService<TrendPostSection> _trendPostSection;

        public TrendPostsController(IPostsSectionService<TrendPostSection> trendPostSection)
        {
            _trendPostSection = trendPostSection;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _trendPostSection.GetAllPosts(p => p.Post.Blog));
        }
    }
}
