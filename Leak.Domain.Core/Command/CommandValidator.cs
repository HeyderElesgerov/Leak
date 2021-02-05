using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Leak.Domain.Core.Command
{
    public abstract class CommandValidator : AbstractValidator<Command>
    {
    }
}
