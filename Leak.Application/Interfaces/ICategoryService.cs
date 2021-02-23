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

        Task<ValidationResult> Add(CategoryViewModel categoryViewModel);

        Task<ValidationResult> Delete(CategoryViewModel categoryViewModel);

        Task<ValidationResult> Update(CategoryViewModel categoryViewModel);
    }
}
