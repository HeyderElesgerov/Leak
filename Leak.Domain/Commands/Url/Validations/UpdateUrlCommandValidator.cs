using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Url.Validations
{
    class UpdateUrlCommandValidator : UrlCommandValidator
    {
        public UpdateUrlCommandValidator()
        {
            ValidateId();
            ValidatePath();
        }
    }
}
