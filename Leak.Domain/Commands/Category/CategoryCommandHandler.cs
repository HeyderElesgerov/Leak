using FluentValidation.Results;
using Leak.Domain.Core.Command;
using Leak.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Category
{
    public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<CreateCategoryCommand, ValidationResult>,
        IRequestHandler<DeleteCategoryCommand, ValidationResult>,
        IRequestHandler<UpdateCategoryCommand, ValidationResult>
    {
        ICategoryRepository _categoryRepository;

        public CategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<ValidationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return Task.FromResult(request.ValidationResult);

            _categoryRepository.Add(new Models.Category(request.CategoryTitle));
            _categoryRepository.Commit();

            return Task.FromResult(ValidationResult);
        }

        public Task<ValidationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return Task.FromResult(request.ValidationResult);

            var category = _categoryRepository.Find(request.Id);

            if(category == null)
            {
                AddError("Category not found");
            }
            else
            {
                _categoryRepository.Delete(category);
                _categoryRepository.Commit();
            }

            return Task.FromResult(ValidationResult);
        }

        public Task<ValidationResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return Task.FromResult(request.ValidationResult);

            var category = _categoryRepository.Find(request.Id);

            if(category == null)
            {
                AddError("Category not found");
            }
            else
            {
                category.ChangeTitle(request.CategoryTitle);

                _categoryRepository.Update(category);
                _categoryRepository.Commit();
            }

            return Task.FromResult(ValidationResult);
        }
    }
}
