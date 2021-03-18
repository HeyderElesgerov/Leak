using AutoMapper;
using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Application.ViewModels.SentPost;
using Leak.Domain.Commands.SentPost;
using Leak.Domain.Models;
using Leak.Domain.Repository;
using MediatR;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leak.Application.Services
{
    public class SentPostService : ISentPostService
    {
        private IMapper _mapper;
        private IMediator _mediator;
        private ISentPostRepository _postRepository;

        public SentPostService(
            IMapper mapper,
            IMediator mediator,
            ISentPostRepository postRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _postRepository = postRepository;
        }

        public async Task<ValidationResult> Add(CreateSentPostViewModel createPostViewModel)
        {
            return await _mediator.Send(
                _mapper.Map<CreateSentPostCommand>(createPostViewModel));
        }

        public async Task<ValidationResult> Approve(int id)
        {
            return await _mediator.Send(new ApproveSentPostCommand(id));
        }

        public async Task<ValidationResult> Delete(int id)
        {
            return await _mediator.Send(new DeleteSentPostCommand(id));
        }

        public async Task<SentPostViewModel> GetById(int id, params Expression<Func<SentPost, object>>[] includes)
        {
            var post = await _postRepository.GetFirstOrDefaultIncluding(p => p.Id == id, includes);
            if (post != null)
                return _mapper.Map<SentPostViewModel>(post);

            return null;
        }
    }
}
