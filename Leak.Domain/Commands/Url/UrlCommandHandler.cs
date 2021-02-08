using FluentValidation.Results;
using Leak.Domain.Core.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Url
{
    class UrlCommandHandler :
        CommandHandler,
        IRequestHandler<CreateUrlCommand, ValidationResult>,
        IRequestHandler<DeleteUrlCommand, ValidationResult>,
        IRequestHandler<UpdateUrlCommand, ValidationResult>
    {
        public Task<ValidationResult> Handle(CreateUrlCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Handle(DeleteUrlCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Handle(UpdateUrlCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
