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
        ISentPostRepository _sentPostRepository;
        IBlogRepository _blogRepository;
        IAppUserRepository _appUserRepository;
        ICategoryRepository _categoryRepository;
        ISpecialPostsSectionRepository<TrendPostSection> _trendingPostsSectionRepository;
        ISpecialPostsSectionRepository<InterestingPostSection> _interestingPostsSectionRepository;

        public UnitOfWork(LeakDbContext db)
        {
            _db = db;
            _postRepository = new PostRepository(db);
            _sentPostRepository = new SentPostRepository(db);
            _blogRepository = new BlogRepository(db);
            _categoryRepository = new CategoryRepository(db);
            _trendingPostsSectionRepository = new SpecialPostsSectionRepository<TrendPostSection>(db);
            _interestingPostsSectionRepository = new SpecialPostsSectionRepository<InterestingPostSection>(db);
            _appUserRepository = new AppUserRepository(db);
        }

        public LeakDbContext Db => _db;
        public IPostRepository PostRepository => _postRepository;
        public ISentPostRepository SentPostRepository => _sentPostRepository;
        public IBlogRepository BlogRepository => _blogRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository;
        public ISpecialPostsSectionRepository<TrendPostSection> TrendingPostsSectionRepository => _trendingPostsSectionRepository;
        public ISpecialPostsSectionRepository<InterestingPostSection> InterestingPostsSectionRepository => _interestingPostsSectionRepository;

        public IAppUserRepository AppUserRepository => _appUserRepository;

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
