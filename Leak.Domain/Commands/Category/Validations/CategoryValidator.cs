using Leak.Domain.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Leak.Domain.Core.ErrorConst;

namespace Leak.Domain.Commands.Category.Validations
{
    public abstract class CategoryValidator<TCommand> : CommandValidator<TCommand> where TCommand : CategoryCommand
    {
        public void ValidateId()
        {
            RuleFor(c => c.Id).GreaterThan(0);
        }

        public void ValidateTitle()
        {
            string fieldName = "Title";

            RuleFor(c => c.CategoryTitle)
                .NotNull().WithMessage(
                ErrorMessageGenerator.Generate(fieldName, ValidationErrors.CannotBeNull));
        }
    }
}
