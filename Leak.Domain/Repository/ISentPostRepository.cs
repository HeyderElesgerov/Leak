using Leak.Domain.Core.Repository;
using Leak.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leak.Domain.Repository
{
    public interface ISentPostRepository : IRepository<SentPost, int>
    {
    }
}
