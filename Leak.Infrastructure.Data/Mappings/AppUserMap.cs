using Leak.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leak.Infrastructure.Data.Mappings
{
    class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

        }
    }
}
