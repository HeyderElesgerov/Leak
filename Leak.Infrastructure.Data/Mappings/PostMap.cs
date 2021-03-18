using Leak.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leak.Infrastructure.Data.Mappings
{
    class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.HeaderPhotoFilePath).IsRequired();

            builder
                .HasOne(p => p.Author)
                .WithMany(a => a.Posts);
        }
    }
}
