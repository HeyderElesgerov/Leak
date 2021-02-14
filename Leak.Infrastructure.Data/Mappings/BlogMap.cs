using Leak.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leak.Infrastructure.Data.Mappings
{
    class BlogMap : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(b => b.Title).IsRequired();
        }
    }
}
