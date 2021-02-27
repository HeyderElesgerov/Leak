using FluentValidation.Results;
using Leak.Application.ViewModels.Post;
using Leak.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leak.Application.Interfaces
{
    public interface IPostsSectionService<TSection>
        where TSection : SpecialPostsSection
    {
        Task<ValidationResult> AddPostToSection(int postId);
        Task<ValidationResult> RemovePostFromSection(int postId);
        Task<IEnumerable<PostViewModel>> GetAllPosts(params Expression<Func<TSection, object>>[] includes);
    }
}
