using Leak.Application.Interfaces;
using Leak.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leak.UI.MVC.ApiControllers.PostSection
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrendingPostsSections : SpecialPostsSectionsController<TrendPostSection>
    {
        public TrendingPostsSections(IPostsSectionService<TrendPostSection> sectionService)
            : base(sectionService)
        {
        }
    }
}
