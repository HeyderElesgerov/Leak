using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using FluentValidation;
using FluentValidation.Results;

namespace Leak.Domain.Core.Command
{
    public abstract class Command : IRequest<ValidationResult>
    {
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            ValidationResult = new ValidationResult();
        }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
