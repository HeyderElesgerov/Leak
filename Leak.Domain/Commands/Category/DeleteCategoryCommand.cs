using Leak.Domain.Commands.Category.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Commands.Category
{
    public class DeleteCategoryCommand : CategoryCommand
    {
        public override bool IsValid()
        {
            ValidationResult = new DeleteCategoryValidator().Validate(this);
            return base.IsValid();
        }
    }
}
