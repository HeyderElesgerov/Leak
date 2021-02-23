namespace Leak.Domain.Commands.Post.Validations
{
    class UpdatePostCommandValidator : PostCommandValidator
    {
        public UpdatePostCommandValidator()
        {
            ValidateTitle();
            ValidateContent();
            ValidatePhotoFileName();
        }
    }
}
