using FluentValidation.Results;
using Leak.Domain.Core.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Post
{
    public class PostCommandHandler :
        CommandHandler,
        IRequestHandler<CreatePostCommand, ValidationResult>,
        IRequestHandler<UpdatePostCommand, ValidationResult>,
        IRequestHandler<DeletePostCommand, ValidationResult>
    {
        public Task<ValidationResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
