using Leak.Domain.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Repository
{
    public interface ISpecialPostsSectionRepository<TSection> : IRepository<TSection, int> where TSection : Models.SpecialPostsSection
    {
    }
}
