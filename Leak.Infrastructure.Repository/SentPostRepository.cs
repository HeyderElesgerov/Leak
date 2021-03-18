using Leak.Domain.Models;
using Leak.Domain.Repository;
using Leak.Infrastructure.Data.Context;

namespace Leak.Infrastructure.Repository
{
    public class SentPostRepository : Repository<SentPost, int>, ISentPostRepository
    {
        public SentPostRepository(LeakDbContext leakDb) : base(leakDb)
        {
        }
    }
}
