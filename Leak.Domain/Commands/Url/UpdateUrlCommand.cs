using Leak.Domain.Commands.Url.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Url
{
    public class UpdateUrlCommand : UrlCommand
    {
        public UpdateUrlCommand(int id, string newPath) : base(id, newPath)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUrlCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
