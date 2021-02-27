using FluentValidation.Results;
using Leak.Application.ViewModels.Category;
using Leak.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.Interfaces
{
    public interface ICategoryService
    {
        CategoryViewModel GetCategory(int id);

        Task<IEnumerable<CategoryViewModel>> GetAllCategories();

        Task<ValidationResult> Add(CreateCategoryViewModel createCategoryViewModel);

        Task<ValidationResult> Delete(int id);

        Task<ValidationResult> Update(UpdateCategoryViewModel updateCategoryViewModel);
    }
}
