using Leak.Domain.Core.Repository;
using Leak.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leak.Domain.Repository
{
    public interface IPostRepository : IRepository<Post, int>
    {
        Task Update(Post post);

        IEnumerable<Post> GetLatestPosts(int count, params Expression<Func<Post, object>>[] includes);
        IEnumerable<Post> GetPaginatedPostsWhere(int skip, int take, Expression<Func<Post, bool>> predicate, params Expression<Func<Post, object>>[] includes);
    }
}
