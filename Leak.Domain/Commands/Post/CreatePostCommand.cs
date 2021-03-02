using Leak.Domain.Commands.Post.Validations;
using System;

namespace Leak.Domain.Commands.Post
{
    public class CreatePostCommand : PostCommand
    {
        public string HeaderPhotoPath { get; set; }
        public Guid AuthorId { get; set; }

        public CreatePostCommand(string title, string content, string headerPhotoPath, int blogId, int categoryId, bool isActive, Guid authorId)
            : base(title, content, blogId, categoryId, isActive)
        {
            HeaderPhotoPath = headerPhotoPath;
            AuthorId = authorId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreatePostCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
