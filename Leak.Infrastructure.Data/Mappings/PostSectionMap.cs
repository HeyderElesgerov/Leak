using Leak.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leak.Infrastructure.Data.Mappings
{
    class PostSectionMap<TSection> : IEntityTypeConfiguration<TSection> where TSection : SpecialPostsSection
    {
        public void Configure(EntityTypeBuilder<TSection> builder)
        {

        }
    }
}
