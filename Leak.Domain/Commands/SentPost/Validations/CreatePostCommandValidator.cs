using FluentValidation;
using Leak.Domain.Commands.Post.Validations;
using Leak.Domain.Core.Command;

namespace Leak.Domain.Commands.SentPost.Validations
{
    class CreateSentPostCommandValidator : CommandValidator<CreateSentPostCommand>
    {
        public CreateSentPostCommandValidator()
        {
            ValidateTitle();
            ValidateContent();
            ValidatePhotoFileName();
        }

        public void ValidatePhotoFileName()
        {
            RuleFor(p => p.HeaderPhotoPath)
                .NotEmpty().WithMessage("Image is required")
                .NotNull().WithMessage("Image is required");
        }

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
    }
}
