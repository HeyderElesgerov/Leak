using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Url.Validations
{
    class CreateUrlCommandValidator : UrlCommandValidator
    {
        public CreateUrlCommandValidator()
        {
            ValidatePath();
        }
    }
}
