using Leak.Domain.Commands.Url.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Post.Validations
{
    class CreatePostCommandValidator : PostCommandValidator
    {
        public CreatePostCommandValidator()
        {
            ValidateTitle();
            ValidateContent();
            ValidatePhotoFileName();
            ValidateUrlPath();
        }

        public void ValidateUrlPath()
        {
            new CreateUrlCommandValidator().ValidatePath();
        }
    }
}
