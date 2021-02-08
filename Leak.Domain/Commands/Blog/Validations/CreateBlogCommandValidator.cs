using Leak.Domain.Commands.Url.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Blog.Validations
{
    class CreateBlogCommandValidator : BlogCommandValidator
    {
        public CreateBlogCommandValidator()
        {
            ValidateTitle();
            ValidateUrlPath();
        }

        public void ValidateUrlPath()
        {
            new CreateUrlCommandValidator().ValidatePath();
        }
    }
}
