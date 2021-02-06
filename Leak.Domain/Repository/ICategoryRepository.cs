using Leak.Domain.Core.Repository;
using Leak.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Repository
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        void Update(Category category);
    }
}
