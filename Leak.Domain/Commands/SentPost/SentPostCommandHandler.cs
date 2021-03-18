using FluentValidation.Results;
using Leak.Domain.Core.Command;
using Leak.Domain.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.SentPost
{
    public class SentPostCommandHandler :
        CommandHandler,
        IRequestHandler<CreateSentPostCommand, ValidationResult>,
        IRequestHandler<DeleteSentPostCommand, ValidationResult>,
        IRequestHandler<ApproveSentPostCommand, ValidationResult>
    {
        IUnitOfWork _unitOfWork;

        public SentPostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ValidationResult> Handle(CreateSentPostCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

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

            var appUser = _unitOfWork.AppUserRepository.FindById(request.AuthorId);

            if (appUser == null)
            {
                AddError("User not found");
                return ValidationResult;
            }

            var newPost = new Models.SentPost(
                request.Title, request.Content, request.HeaderPhotoPath, blogId, categoryId, appUser);

            await _unitOfWork.SentPostRepository.Add(newPost);
            await _unitOfWork.Commit();

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(DeleteSentPostCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            if (SentPostExists(request.Id))
            {
                var post = _unitOfWork.SentPostRepository.Find(request.Id);

                await _unitOfWork.SentPostRepository.Delete(post);
                await _unitOfWork.Commit();
            }
            else
            {
                AddError("Sent Post not found");
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(ApproveSentPostCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            if (SentPostExists(request.Id))
            {
                var sentPost = await _unitOfWork.SentPostRepository.GetFirstIncluding(request.Id, p => p.Author, p => p.ApprovedPost);

                if(sentPost.ApprovedPost != null)
                {
                    AddError("Post has already been updated");
                    return ValidationResult;
                }

                var newPost = new Models.Post(sentPost.Title, sentPost.Content, sentPost.HeaderPhotoFilePath, true, sentPost.BlogId, sentPost.CategoryId, sentPost.Author);

                await _unitOfWork.PostRepository.Add(newPost);
                sentPost.ApprovedPost = newPost;
                await _unitOfWork.Commit();
            }
            else
            {
                AddError("Sent Post not found");
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
        private bool SentPostExists(int id)
        {
            return _unitOfWork.SentPostRepository.Find(id) != null;
        }
    }
}
