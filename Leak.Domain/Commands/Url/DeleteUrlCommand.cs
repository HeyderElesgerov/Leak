using Leak.Domain.Commands.Url.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Url
{
    public class DeleteUrlCommand : UrlCommand
    {
        public DeleteUrlCommand(int id) : base(id, String.Empty)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteUrlCommandValidator().Validate(this);
            return base.IsValid();
        }
    }
}
