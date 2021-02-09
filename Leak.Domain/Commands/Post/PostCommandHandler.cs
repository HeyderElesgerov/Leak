using FluentValidation.Results;
using Leak.Domain.Core.Command;
using Leak.Domain.UnitOfWork;
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
        IRequestHandler<DeletePostCommand, ValidationResult>,
        IRequestHandler<IncreaseReadingCountCommand, ValidationResult>
    {
        IUnitOfWork _unitOfWork;

        public PostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            int blogId = request.BlogId;
            int categoryId = request.CategoryId;

            if (!BlogExists(blogId))
            {
                AddError("Blog not found");
                return ValidationResult;
            }
            if (!CategoryExists(categoryId))
            {
                AddError("Category not found");
                return ValidationResult;
            }

            var newPost = new Models.Post(
                request.Title, request.Content, request.HeaderPhotoName,
                new Models.Url(request.UrlPath), request.IsActive, blogId, categoryId);

            await _unitOfWork.PostRepository.Add(newPost);
            await _unitOfWork.Commit();

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            int postId = request.Id;

            if (PostExists(postId))
            {
                int blogId = request.BlogId;
                int categoryId = request.CategoryId;

                if (!BlogExists(blogId))
                {
                    AddError("Blog not found");
                    return ValidationResult;
                }
                if (!CategoryExists(categoryId))
                {
                    AddError("Category not found");
                    return ValidationResult;
                }

                var post = _unitOfWork.PostRepository.Find(postId);

                post.ChangeTitle(request.Title);
                post.ChangeContent(request.Content);
                post.ChangePhotoFileName(request.HeaderPhotoName);
                post.BlogId = blogId;
                post.CategoryId = categoryId;

                await _unitOfWork.Commit();
            }
            else
            {
                AddError("Post not found");
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            if (PostExists(request.Id))
            {
                var post = await _unitOfWork.PostRepository
                                            .GetFirstIncluding(request.Id, p => p.Url);

                await _unitOfWork.PostRepository.Delete(post);

                if (post.Url != null)
                    await _unitOfWork.UrlRepository.Delete(post.Url);

                await _unitOfWork.Commit();
            }
            else
            {
                AddError("Post not found");
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(IncreaseReadingCountCommand request, CancellationToken cancellationToken)
        {
            if (!PostExists(request.Id))
                AddError("Post not found");
            else
            {
                var post = _unitOfWork.PostRepository.Find(request.Id);
                post.IncreaseReadingCount();

                await _unitOfWork.Commit();
            }

            return ValidationResult;
        }

        private bool BlogExists(int id)
        {
            return _unitOfWork.BlogRepository.Find(id) != null;
        }
        private bool CategoryExists(int id)
        {
            return _unitOfWork.CategoryRepository.Find(id) != null;
        }
        private bool PostExists(int id)
        {
            return _unitOfWork.PostRepository.Find(id) != null;
        }
    }
}
