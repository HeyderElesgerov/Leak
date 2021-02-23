using AutoMapper;
using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Blog;
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

        public async Task<ValidationResult> Add(CreateBlogViewModel createBlogViewModel)
        {
            CreateBlogCommand createBlogCommand =
                _mapper.Map<CreateBlogCommand>(createBlogViewModel);

            return await _mediator.Send(createBlogCommand);
        }

        public async Task<ValidationResult> Delete(int id)
        {
            DeleteBlogCommand deleteCategoryCommand = new DeleteBlogCommand(id);

            return await _mediator.Send(deleteCategoryCommand);
        }

        public async Task<IEnumerable<BlogViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<BlogViewModel>>(
                await _blogRepository.GetAll());
        }

        public async Task<ValidationResult> Update(UpdateBlogViewModel updateBlogViewModel)
        {
            UpdateBlogCommand updateBlogCommand = _mapper.Map<UpdateBlogCommand>(updateBlogViewModel);
            return await _mediator.Send(updateBlogCommand);
        }
    }
}
