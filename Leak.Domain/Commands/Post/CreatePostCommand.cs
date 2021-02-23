using Leak.Domain.Commands.Post.Validations;

namespace Leak.Domain.Commands.Post
{
    public class CreatePostCommand : PostCommand
    {
        public CreatePostCommand(string title, string content, string headerPhotoName, int blogId, int categoryId, bool isActive)
            : base(title, content, headerPhotoName, blogId, categoryId, isActive)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new CreatePostCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
