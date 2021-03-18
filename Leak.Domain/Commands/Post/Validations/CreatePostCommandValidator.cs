using FluentValidation;

namespace Leak.Domain.Commands.Post.Validations
{
    class CreatePostCommandValidator : PostCommandValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
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
    }
}
