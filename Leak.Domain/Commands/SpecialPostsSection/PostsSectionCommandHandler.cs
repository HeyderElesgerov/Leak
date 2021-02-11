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

namespace Leak.Domain.Commands.SpecialPostsSection
{
    public class PostsSectionCommandHandler<TSection> : CommandHandler,
        IRequestHandler<AddPostToPostsSectionCommand<TSection>, ValidationResult>,
        IRequestHandler<RemovePostFromPostsSectionCommand<TSection>, ValidationResult>
        where TSection : Models.SpecialPostsSection, new()
    {
        private readonly ISpecialPostsSectionRepository<TSection> _sectionRepository;

        //we jus use to fetch, not save
        private readonly IPostRepository _postRepository;

        public PostsSectionCommandHandler(ISpecialPostsSectionRepository<TSection> repo, IPostRepository postRepository)
        {
            _sectionRepository = repo;
            _postRepository = postRepository;
        }

        public async Task<ValidationResult> Handle(AddPostToPostsSectionCommand<TSection> request, CancellationToken cancellationToken)
        {
            int postId = request.PostId;
            bool postExists = await _postRepository.Any(p => p.Id == postId);

            if (!postExists)
            {
                AddError("Post not found");
            }
            else
            {
                bool postExistsInThisSection = await _sectionRepository.Any(s => s.PostId == postId);

                if (postExistsInThisSection)
                {
                    AddError("This post already in this section");
                }
                else
                {
                    await _sectionRepository.Add(new TSection() { PostId = postId });
                    await _sectionRepository.Commit();
                }
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(RemovePostFromPostsSectionCommand<TSection> request, CancellationToken cancellationToken)
        {
            int postId = request.PostId;

            TSection section = (await _sectionRepository.GetWhere(s => s.Id == postId)).FirstOrDefault();

            if (section != null)
            {
                AddError("Post already not in this section");
            }
            else
            {
                await _sectionRepository.Delete(section);
                await _sectionRepository.Commit();
            }

            return ValidationResult;
        }
    }
}
