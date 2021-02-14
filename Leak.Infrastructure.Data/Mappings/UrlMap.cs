using Leak.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leak.Infrastructure.Data.Mappings
{
    class UrlMap : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.Property(u => u.Path).IsRequired();
        }
    }
}
