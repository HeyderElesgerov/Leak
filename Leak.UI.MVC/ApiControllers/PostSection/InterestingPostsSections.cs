using Leak.Application.Interfaces;
using Leak.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leak.UI.MVC.ApiControllers.PostSection
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestingPostsSections : SpecialPostsSectionsController<InterestingPostSection>
    {
        public InterestingPostsSections(IPostsSectionService<InterestingPostSection> sectionService)
            : base(sectionService)
        {
        }
    }
}
