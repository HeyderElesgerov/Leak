using Leak.Domain.Commands.Post.Validations;
using Leak.Domain.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Post
{
    public class CreatePostCommand : PostCommand
    {
        public CreatePostCommand()
        {
        }

        public CreatePostCommand(string title, string content, string headerPhotoName, string urlPath, int blogId, int categoryId, bool isActive) 
            : base(title, content, headerPhotoName, blogId, categoryId, isActive)
        {
            UrlPath = urlPath;
        }

        public string UrlPath { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreatePostCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
