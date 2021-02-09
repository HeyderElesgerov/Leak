using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Post.Validations
{
    class UpdatePostCommandValidator : PostCommandValidator
    {
        public UpdatePostCommandValidator()
        {
            ValidateTitle();
            ValidateContent();
            ValidatePhotoFileName();
        }
    }
}
