using Leak.Domain.Commands.Post.Validations;
using Leak.Domain.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Post
{
    public class UpdatePostCommand : PostCommand
    {
        public int Id { get; set; }

        public UpdatePostCommand()
        {
        }

        public UpdatePostCommand(int id, string title, string content, string headerPhotoName, int blogId, int categoryId, bool isActive) 
            : base(title, content, headerPhotoName, blogId, categoryId, isActive)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePostCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
