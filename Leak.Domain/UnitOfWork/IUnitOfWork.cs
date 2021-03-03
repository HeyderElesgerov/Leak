using Leak.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace Leak.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        ISentPostRepository SentPostRepository { get; }
        IBlogRepository BlogRepository { get; }
        IAppUserRepository AppUserRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ISpecialPostsSectionRepository<Models.TrendPostSection> TrendingPostsSectionRepository { get; }
        ISpecialPostsSectionRepository<Models.InterestingPostSection> InterestingPostsSectionRepository { get; }

        Task Commit();
    }
}
