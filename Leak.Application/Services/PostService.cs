using AutoMapper;
using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Post;
using Leak.Domain.Commands.Post;
using Leak.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.Services
{
    public class PostService : IPostService
    {
        private IMapper _mapper;
        private IMediator _mediator;
        private IPostRepository _postRepository;

        public PostService(
            IMapper mapper,
            IMediator mediator,
            IPostRepository postRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _postRepository = postRepository;
        }

        public async Task<ValidationResult> Add(CreatePostViewModel createPostViewModel)
        {
            return await _mediator.Send(
                _mapper.Map<CreatePostCommand>(createPostViewModel));
        }

        public async Task<ValidationResult> Delete(int id)
        {
            return await _mediator.Send(new DeletePostCommand(id));
        }

        public async Task<ValidationResult> IncreaseReadingCount(int id)
        {
            return await _mediator.Send(new IncreaseReadingCountCommand(id));
        }

        public async Task<ValidationResult> Update(UpdatePostViewModel updatePostViewModel)
        {
            return await _mediator.Send(
                _mapper.Map<UpdatePostCommand>(updatePostViewModel));
        }
    }
}
