using Leak.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leak.Infrastructure.Data.Mappings
{
    class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(p => p.PhotoFileName).IsRequired();
            builder
                .HasMany(p => p.Posts)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
