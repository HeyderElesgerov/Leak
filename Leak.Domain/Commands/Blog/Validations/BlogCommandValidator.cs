using Leak.Domain.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Leak.Domain.Commands.Blog.Validations
{
    class BlogCommandValidator<TBlogCommand> : CommandValidator<TBlogCommand> where TBlogCommand : BlogCommand
    {
        public void ValidateTitle()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Title is required").WithName("Title")
                .NotNull().WithMessage("Title is required").WithName("Title");
        }
    }
}
