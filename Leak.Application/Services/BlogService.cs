using AutoMapper;
using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Blog;
using Leak.Application.ViewModels.Category;
using Leak.Domain.Commands.Blog;
using Leak.Domain.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leak.Application.Services
{
    public class BlogService : IBlogService
    {
        private IMapper _mapper;
        private IMediator _mediator;
        private IBlogRepository _blogRepository;

        public BlogService(
            IMapper mapper,
            IMediator mediator,
            IBlogRepository blogRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _blogRepository = blogRepository;
        }

        public async Task<ValidationResult> Add(BlogViewModel blogViewModel)
        {
            CreateBlogCommand createBlogCommand =
                _mapper.Map<CreateBlogCommand>(blogViewModel);

            return await _mediator.Send(createBlogCommand);
        }

        public async Task<ValidationResult> Delete(BlogViewModel blogViewModel)
        {
            DeleteBlogCommand deleteCategoryCommand = _mapper.Map<DeleteBlogCommand>(blogViewModel);

            return await _mediator.Send(deleteCategoryCommand);
        }

        public async Task<IEnumerable<BlogViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<BlogViewModel>>(
                await _blogRepository.GetAll());
        }
    }
}
