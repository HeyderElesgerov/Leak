using Leak.Domain.Commands.Post.Validations;

namespace Leak.Domain.Commands.Post
{
    public class CreatePostCommand : PostCommand
    {
        public string HeaderPhotoPath { get; set; }

        public CreatePostCommand(string title, string content, string headerPhotoPath, int blogId, int categoryId, bool isActive)
            : base(title, content, blogId, categoryId, isActive)
        {
            HeaderPhotoPath = headerPhotoPath;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreatePostCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
