using FluentValidation.Results;
using Leak.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.Interfaces
{
    public interface IPostService
    {
        Task<ValidationResult> Add(CreatePostViewModel createPostViewModel);
        Task<ValidationResult> Update(UpdatePostViewModel updatePostViewModel);
        Task<ValidationResult> Delete(int id);
        Task<ValidationResult> IncreaseReadingCount(int id);
    }
}
