using FluentValidation.Results;
using Leak.Domain.Core.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.SpecialPostsSection
{
    public class PostsSectionCommandHandler<TSection> : CommandHandler,
        IRequestHandler<AddPostToPostsSectionCommand<TSection>, ValidationResult>,
        IRequestHandler<RemovePostFromPostsSectionCommand<TSection>, ValidationResult>
        where TSection : Models.SpecialPostsSection
    {
        public Task<ValidationResult> Handle(AddPostToPostsSectionCommand<TSection> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> Handle(RemovePostFromPostsSectionCommand<TSection> request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
