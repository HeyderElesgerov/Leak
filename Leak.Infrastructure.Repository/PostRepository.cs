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
    public class PostRepository : Repository<Post, int>, IPostRepository
    {
        public PostRepository(LeakDbContext leakDb) : base(leakDb)
        {
        }

        public Task Update(Post post)
        {
            return Task.Run(() => Entities.Update(post));
        }
    }
}
