using FluentValidation.Results;
using Leak.Domain.Core.Command;
using Leak.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Blog
{
    public class BlogCommandHandler :
        CommandHandler,
        IRequestHandler<CreateBlogCommand, ValidationResult>,
        IRequestHandler<DeleteBlogCommand, ValidationResult>,
        IRequestHandler<UpdateBlogCommand, ValidationResult>
    {
        private readonly IBlogRepository _blogRepository;

        public BlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<ValidationResult> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            Models.Blog blog = 
                new Models.Blog(request.Title);

            await _blogRepository.Add(blog);
            await _blogRepository.Commit();

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var blog = _blogRepository.Find(request.Id);

            if (blog == null)
                AddError("Blog not found");
            else
            {
                await _blogRepository.Delete(blog);
                await _blogRepository.Commit();
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            Models.Blog existingBlog = _blogRepository.Find(request.Id);

            if(existingBlog == null)
                AddError("Blog not found");
            else
            {
                if(request.Title != existingBlog.Title)
                    existingBlog.ChangeTitle(request.Title);

                await _blogRepository.Update(existingBlog);
                await _blogRepository.Commit();
            }

            return ValidationResult;
        }
    }
}
