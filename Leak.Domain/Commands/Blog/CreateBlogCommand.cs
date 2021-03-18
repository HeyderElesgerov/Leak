using Leak.Domain.Commands.Blog.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Blog
{
    public class CreateBlogCommand : BlogCommand
    {
        public CreateBlogCommand(string title) : base(0, title)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateBlogCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
