namespace Leak.Domain.Commands.Post.Validations
{
    class CreatePostCommandValidator : PostCommandValidator
    {
        public CreatePostCommandValidator()
        {
            ValidateTitle();
            ValidateContent();
            ValidatePhotoFileName();
        }
    }
}
