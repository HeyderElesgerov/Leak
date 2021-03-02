using Leak.Domain.Core.Repository;
using Leak.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Repository
{
    public interface IAppUserRepository
    {
        bool Exists(Guid guid);

        AppUser FindById(Guid guid);
    }
}
