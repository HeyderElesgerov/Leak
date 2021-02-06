using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Commands.Category.Validations
{
    public class DeleteCategoryValidator : CategoryValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            ValidateId();
        }
    }
}
