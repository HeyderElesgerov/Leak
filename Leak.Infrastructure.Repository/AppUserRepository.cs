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
    public class AppUserRepository : IAppUserRepository
    {
        LeakDbContext _leakDb;

        public AppUserRepository(LeakDbContext leakDb)
        {
            _leakDb = leakDb;
        }

        public bool Exists(Guid guid)
        {
            var user = FindById(guid); 
            return user != null;
        }

        public AppUser FindById(Guid guid)
        {
            return _leakDb.Set<AppUser>().Find(guid);
        }
    }
}
