using AutoMapper;
using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Post;
using Leak.Domain.Commands.Post;
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

        public async Task<PostViewModel> GetById(int id, params Expression<Func<Post, object>>[] includes)
        {
            var post = await _postRepository.GetFirstOrDefaultIncluding(p => p.Id == id, includes);
            if(post != null)
                return _mapper.Map<PostViewModel>(post);

            return null;
        }

        public IEnumerable<PostViewModel> GetLatestPosts(int count, params Expression<Func<Post, object>>[] includes)
        {
            var latestsPosts =  _postRepository.GetLatestPosts(count, includes);
            List<PostViewModel> postViewModels = new List<PostViewModel>();
            foreach(var post in latestsPosts)
            {
                postViewModels.Add(_mapper.Map<PostViewModel>(post));
            }

            return postViewModels;
        }

        public async Task<IEnumerable<PostViewModel>> GetPostsByBlog(int blogId, params Expression<Func<Post, object>>[] includes)
        {
            var posts = await _postRepository.GetWhereIncluding(p => p.BlogId == blogId, includes);
            List<PostViewModel> postViewModels = new List<PostViewModel>();
            foreach (var post in posts)
            {
                postViewModels.Add(_mapper.Map<PostViewModel>(post));
            }

            return postViewModels;
        }

        public IEnumerable<PostViewModel> GetPaginatedPosts(int page, int elementCountPerPage, Expression<Func<Post, bool>> predicate, params Expression<Func<Post, object>>[] includes)
        {
            int skip = (page - 1) * elementCountPerPage;
            int take = elementCountPerPage;
            var posts = _postRepository.GetPaginatedPostsWhere(skip, take, predicate, includes);

            return posts.Select(p => _mapper.Map<PostViewModel>(p));
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
