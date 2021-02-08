using Leak.Domain.Commands.Url.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Url
{
    public class CreateUrlCommand : UrlCommand
    {
        public CreateUrlCommand(string path) : base(default(int), path)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateUrlCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
