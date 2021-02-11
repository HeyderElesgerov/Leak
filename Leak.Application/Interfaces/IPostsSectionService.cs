using FluentValidation.Results;
using Leak.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leak.Application.Interfaces
{
    public interface IPostsSectionService<TSection>
        where TSection : SpecialPostsSection
    {
        Task<ValidationResult> AddPostToSection(int postId);
        Task<ValidationResult> RemovePostFromSection(int postId);
    }
}
