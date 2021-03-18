using AutoMapper;
using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Post;
using Leak.Domain.Commands.SpecialPostsSection;
using Leak.Domain.Models;
using Leak.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leak.Application.Services
{
    public class PostsSectionService<TSection> : IPostsSectionService<TSection>
        where TSection : SpecialPostsSection
    {
        private IMapper _mapper;
        private IMediator _mediator;
        private ISpecialPostsSectionRepository<TSection> _repo;

        public PostsSectionService(IMediator mediator, ISpecialPostsSectionRepository<TSection> repo, IMapper mapper)
        {
            _mediator = mediator;
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ValidationResult> AddPostToSection(int postId)
        {
            return await _mediator.Send(new AddPostToPostsSectionCommand<TSection>(postId));
        }

        public async Task<IEnumerable<PostViewModel>> GetAllPosts(params Expression<Func<TSection, object>>[] includes)
        {
            var sections = await _repo.GetAllIncluding(includes);
            return sections.Select(s => _mapper.Map<PostViewModel>(s.Post));
        }

        public async Task<ValidationResult> RemovePostFromSection(int postId)
        {
            return await _mediator.Send(new RemovePostFromPostsSectionCommand<TSection>(postId));
        }
    }
}
