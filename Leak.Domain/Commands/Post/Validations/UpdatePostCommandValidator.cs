namespace Leak.Domain.Commands.Post.Validations
{
    class UpdatePostCommandValidator : PostCommandValidator<UpdatePostCommand>
    {
        public UpdatePostCommandValidator()
        {
            ValidateTitle();
            ValidateContent();
        }
    }
}
