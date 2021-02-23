using Leak.Domain.Models;
using Leak.Domain.Repository;
using Leak.Domain.UnitOfWork;
using Leak.Infrastructure.Data.Context;
using System.Threading.Tasks;

namespace Leak.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        LeakDbContext _db;
        IPostRepository _postRepository;
        IBlogRepository _blogRepository;
        ICategoryRepository _categoryRepository;
        ISpecialPostsSectionRepository<TrendPostSection> _trendingPostsSectionRepository;
        ISpecialPostsSectionRepository<InterestingPostSection> _interestingPostsSectionRepository;

        public UnitOfWork(LeakDbContext db)
        {
            _db = db;
            _postRepository = new PostRepository(db);
            _blogRepository = new BlogRepository(db);
            _categoryRepository = new CategoryRepository(db);
            _trendingPostsSectionRepository = new SpecialPostsSectionRepository<TrendPostSection>(db);
            _interestingPostsSectionRepository = new SpecialPostsSectionRepository<InterestingPostSection>(db);
        }

        public LeakDbContext Db { get => _db; }
        public IPostRepository PostRepository { get => _postRepository; }
        public IBlogRepository BlogRepository { get => _blogRepository; }
        public ICategoryRepository CategoryRepository { get => _categoryRepository; }
        public ISpecialPostsSectionRepository<TrendPostSection> TrendingPostsSectionRepository
        { get => _trendingPostsSectionRepository; }
        public ISpecialPostsSectionRepository<InterestingPostSection> InterestingPostsSectionRepository
        { get => _interestingPostsSectionRepository; }

        public async Task Commit()
        {
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
