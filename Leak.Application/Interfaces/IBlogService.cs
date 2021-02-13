using FluentValidation.Results;
using Leak.Application.ViewModels.Blog;
using Leak.Application.ViewModels.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leak.Application.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogViewModel>> GetAll();

        Task<ValidationResult> Add(BlogViewModel blogViewModel);

        Task<ValidationResult> Delete(int id);
    }
}
