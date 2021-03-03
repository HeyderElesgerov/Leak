using Leak.Domain.Commands.SentPost.Validations;
using Leak.Domain.Core.Command;
using System;

namespace Leak.Domain.Commands.SentPost
{
    public class CreateSentPostCommand : Command
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public string HeaderPhotoPath { get; set; }
        public Guid AuthorId { get; set; }

        public CreateSentPostCommand(string title, string content, string headerPhotoPath, int blogId, int categoryId, Guid authorId)
        {
            Title = title;
            Content = content;
            HeaderPhotoPath = headerPhotoPath;
            BlogId = blogId;
            CategoryId = categoryId;
            AuthorId = authorId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateSentPostCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
