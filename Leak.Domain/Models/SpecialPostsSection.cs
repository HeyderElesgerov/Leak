using Leak.Domain.Core.Entity;

namespace Leak.Domain.Models
{
    public class SpecialPostsSection : BaseEntity<int>
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
