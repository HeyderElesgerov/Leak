using Leak.Domain.Commands.Blog.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Blog
{
    public class CreateBlogCommand : BlogCommand
    {
        public string UrlPath { get; set; }

        public CreateBlogCommand(string title, string urlPath) : base(0, title)
        {
            UrlPath = urlPath;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateBlogCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
