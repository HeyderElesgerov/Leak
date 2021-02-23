using Leak.Domain.Models;
using Leak.Infrastructure.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Leak.Infrastructure.Data.Context
{
    public class LeakDbContext : IdentityDbContext
    {
        public LeakDbContext(DbContextOptions<LeakDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new BlogMap());
            builder.ApplyConfiguration(new PostMap());
            builder.ApplyConfiguration(new PostSectionMap<InterestingPostSection>());
            builder.ApplyConfiguration(new PostSectionMap<TrendPostSection>());
            builder.ApplyConfiguration(new AppUserMap());

            base.OnModelCreating(builder);
        }
    }
}
