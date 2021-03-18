using Leak.Domain.Models;
using Leak.Domain.Repository;
using Leak.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Infrastructure.Repository
{
    public class PostRepository : Repository<Post, int>, IPostRepository
    {
        public PostRepository(LeakDbContext leakDb) : base(leakDb)
        {
        }

        public IEnumerable<Post> GetLatestPosts(int count, params Expression<Func<Post, object>>[] includes)
        {
            var entities =  Entities
                            .OrderByDescending(e => e.DatePublished)
                            .Take(count);

            if(includes != null)
            {
                foreach(var include in includes)
                {
                    entities =  entities.Include(include);
                }
            }

            return entities.AsEnumerable();
        }

        public IEnumerable<Post> GetPaginatedPostsWhere(int skip, int take, Expression<Func<Post, bool>> predicate, params Expression<Func<Post, object>>[] includes)
        {
            var entities = Entities.Where(predicate)
                                    .OrderByDescending(e => e.DatePublished)
                                    .Skip(skip)
                                    .Take(take);

            if(includes != null)
            {
                foreach (var include in includes)
                {
                    entities = entities.Include(include);
                }
            }

            return entities.AsEnumerable();
        }

        public Task Update(Post post)
        {
            return Task.Run(() => Entities.Update(post));
        }
    }
}
