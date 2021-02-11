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
        IPostRepository PostRepository { get; set; }
        IBlogRepository BlogRepository { get; set; }
        ICategoryRepository CategoryRepository { get; set; }
        IUrlRepository UrlRepository { get; set; }
        ISpecialPostsSectionRepository<Models.TrendPostSection> TrendingPostsSectionRepository { get; set; }
        ISpecialPostsSectionRepository<Models.InterestingPostSection> InterestingPostsSectionRepository { get; set; }

        Task Commit();
    }
}
