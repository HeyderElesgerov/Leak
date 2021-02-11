using Leak.Domain.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.SpecialPostsSection
{
    public class AddPostToPostsSectionCommand<TSection> : Command
        where TSection : Models.SpecialPostsSection
    {
        public int PostId { get; set; }
        
        public AddPostToPostsSectionCommand(int postId)
        {
            PostId = postId;
        }
    }
}
