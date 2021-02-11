using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Domain.Commands.SpecialPostsSection;
using Leak.Domain.Models;
using MediatR;
using System.Threading.Tasks;

namespace Leak.Application.Services
{
    public class PostsSectionService<TSection> : IPostsSectionService<TSection>
        where TSection : SpecialPostsSection
    {
        private IMediator _mediator;

        public PostsSectionService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> AddPostToSection(int postId)
        {
            return await _mediator.Send(new AddPostToPostsSectionCommand<TSection>(postId));
        }

        public async Task<ValidationResult> RemovePostFromSection(int postId)
        {
            return await _mediator.Send(new RemovePostFromPostsSectionCommand<TSection>(postId));
        }
    }
}
