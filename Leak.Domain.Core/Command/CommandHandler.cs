using FluentValidation.Results;
using System.Collections.Generic;

namespace Leak.Domain.Core.Command
{
    public abstract class CommandHandler
    {
        public ValidationResult ValidationResult { get; set; }

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected CommandHandler(IEnumerable<ValidationFailure> validationFailures)
        {
            ValidationResult = new ValidationResult(validationFailures);
        }

        public void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure("", message));
        }
    }
}
