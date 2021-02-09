using Leak.Domain.Core.Repository;
using Leak.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Repository
{
    public interface IPostRepository : IRepository<Post, int>
    {
        Task Update(Post post);
    }
}
