using Leak.Domain.Commands.Blog.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Blog
{
    public class UpdateBlogCommand : BlogCommand
    {
        public UpdateBlogCommand(int id, string title) : base(id, title)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateBlogCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
