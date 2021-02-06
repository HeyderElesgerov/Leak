using FluentValidation;
using Leak.Domain.Core.Command;
using Leak.Domain.Core.ErrorConst;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Commands.Category.Validations
{
    public class CreateCategoryValidator : CategoryValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            ValidateTitle();
        }
    }
}
