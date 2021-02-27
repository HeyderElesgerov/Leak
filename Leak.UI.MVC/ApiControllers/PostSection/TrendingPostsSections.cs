using Leak.Application.Interfaces;
using Leak.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leak.UI.MVC.ApiControllers
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
