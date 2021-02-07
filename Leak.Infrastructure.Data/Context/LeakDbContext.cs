using Leak.Domain.Models;
using Leak.Infrastructure.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Infrastructure.Data.Context
{
    public class LeakDbContext : IdentityDbContext
    {
        public LeakDbContext(DbContextOptions<LeakDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryMap());

            base.OnModelCreating(builder);
        }
    }
}
