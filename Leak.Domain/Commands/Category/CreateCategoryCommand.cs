﻿using Leak.Domain.Commands.Category.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Commands.Category
{
    public class CreateCategoryCommand : CategoryCommand
    {
        public CreateCategoryCommand(string title) : base(default(int), title)
        {
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateCategoryValidator().Validate(this);
            return base.IsValid();
        }
    }
}
