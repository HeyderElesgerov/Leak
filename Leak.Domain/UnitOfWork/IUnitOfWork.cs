using Leak.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        IBlogRepository BlogRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IUrlRepository UrlRepository { get; }
        ISpecialPostsSectionRepository<Models.TrendPostSection> TrendingPostsSectionRepository { get; }
        ISpecialPostsSectionRepository<Models.InterestingPostSection> InterestingPostsSectionRepository { get; }

        Task Commit();
    }
}
