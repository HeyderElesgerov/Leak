using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Blog
{
    public class DeleteBlogCommand : BlogCommand
    {
        public DeleteBlogCommand(int id) : base(id, string.Empty)
        {
        }

        public override bool IsValid()
        {
            return base.IsValid();
        }
    }
}
