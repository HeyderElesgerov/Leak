using FluentValidation.Results;
using Leak.Domain.Core.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Category
{
    public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<CreateCategoryCommand, ValidationResult>,
        IRequestHandler<DeleteCategoryCommand, ValidationResult>
    {
        public Task<ValidationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
