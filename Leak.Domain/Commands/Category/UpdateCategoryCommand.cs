using Leak.Domain.Commands.Category.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Commands.Category
{
    public class UpdateCategoryCommand : CategoryCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoryValidator().Validate(this);
            return base.IsValid();
        }
    }
}
