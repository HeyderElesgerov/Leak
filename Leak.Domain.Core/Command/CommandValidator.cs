using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Leak.Domain.Core.Command
{
    public abstract class CommandValidator<TCommand> : AbstractValidator<TCommand> where TCommand : Command
    {
    }
}
