using Leak.Domain.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Leak.Domain.Commands.Url.Validations
{
    abstract class UrlCommandValidator : CommandValidator<UrlCommand>
    {
        public void ValidateId()
        {
            RuleFor(u => u.Id).GreaterThan(0);
        }

        public void ValidatePath()
        {
            RuleFor(u => u.Path)
                .NotEmpty().WithMessage("Path cannot be empty")
                .NotNull().WithMessage("Path is required");
        }
    }
}
