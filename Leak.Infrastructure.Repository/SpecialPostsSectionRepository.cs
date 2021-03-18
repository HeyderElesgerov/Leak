using Leak.Domain.Models;
using Leak.Domain.Repository;
using Leak.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Infrastructure.Repository
{
    public class SpecialPostsSectionRepository<TSection> : Repository<TSection, int>, ISpecialPostsSectionRepository<TSection>
        where TSection : SpecialPostsSection
    {
        public SpecialPostsSectionRepository(LeakDbContext leakDb) : base(leakDb)
        {
        }
    }
}
