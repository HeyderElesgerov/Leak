using Leak.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leak.Infrastructure.Data.Mappings
{
    class SentPostMap : IEntityTypeConfiguration<SentPost>
    {
        public void Configure(EntityTypeBuilder<SentPost> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.HeaderPhotoFilePath).IsRequired();
        }
    }
}
