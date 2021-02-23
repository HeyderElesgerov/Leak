using FluentValidation;
using Leak.Domain.Core.Command;

namespace Leak.Domain.Commands.Post.Validations
{
    class PostCommandValidator : CommandValidator<PostCommand>
    {
        public void ValidateTitle()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("Title is required")
                .NotNull().WithMessage("Title is required");
        }

        public void ValidateContent()
        {
            RuleFor(p => p.Content)
                .NotEmpty().WithMessage("Content is required")
                .NotNull().WithMessage("Content is required");
        }

        public void ValidatePhotoFileName()
        {
            RuleFor(p => p.HeaderPhotoName)
                .NotEmpty().WithMessage("Image is required")
                .NotNull().WithMessage("Image is required");
        }
    }
}
