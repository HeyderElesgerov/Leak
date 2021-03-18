using FluentValidation;

namespace Leak.Domain.Commands.Blog.Validations
{
    class UpdateBlogCommandValidator : BlogCommandValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator()
        {
            ValidateTitle();
        }
    }
}
