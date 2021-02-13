using Leak.Domain.Models;
using Leak.Domain.Repository;
using Leak.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Infrastructure.Repository
{
    public class UrlRepository : Repository<Url, int>, IUrlRepository
    {
        public UrlRepository(LeakDbContext leakDb) : base(leakDb)
        {
        }

        public void Update(Url url)
        {
            Entities.Update(url);
        }
    }
}
