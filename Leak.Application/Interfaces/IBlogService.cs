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

        Task<ValidationResult> Add(CreateBlogViewModel createBlogViewModel);

        Task<ValidationResult> Update(UpdateBlogViewModel updateBlogViewModel);

        Task<ValidationResult> Delete(int id);
    }
}
