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
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(LeakDbContext leakDb) : base(leakDb)
        {

        }

        public void Update(Category category)
        {
            Entities.Update(category);
        }
    }
}
