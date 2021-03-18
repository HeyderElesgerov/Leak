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
    public class BlogRepository : Repository<Blog, int>, IBlogRepository
    {
        public BlogRepository(LeakDbContext leakDb) : base(leakDb)
        {
        }

        public Task Update(Blog blog)
        {
            Entities.Update(blog);
            return Task.CompletedTask;
        }
    }
}
