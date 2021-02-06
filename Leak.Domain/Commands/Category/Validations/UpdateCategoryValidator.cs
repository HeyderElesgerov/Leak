using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Commands.Category.Validations
{
    public class UpdateCategoryValidator : CategoryValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            ValidateId();
            ValidateTitle();
        }
    }
}
