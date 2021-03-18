using FluentValidation;

namespace Leak.Domain.Commands.Blog.Validations
{
    class CreateBlogCommandValidator : BlogCommandValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            ValidateTitle();
        }
    }
}
