using AutoMapper;
using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Category;
using Leak.Domain.Commands.Category;
using Leak.Domain.Models;
using Leak.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private IMapper _mapper;
        private IMediator _mediator;
        private ICategoryRepository _categoryRepository;

        public CategoryService(
            IMapper mapper, 
            IMediator mediator, 
            ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _categoryRepository = categoryRepository;
        }

        public async Task<ValidationResult> Add(CategoryViewModel categoryViewModel)
        {
            CreateCategoryCommand createCategoryCommand = 
                _mapper.Map<CreateCategoryCommand>(categoryViewModel);

            return await _mediator.Send(createCategoryCommand);
        }

        public async Task<ValidationResult> Delete(CategoryViewModel categoryViewModel)
        {
            DeleteCategoryCommand deleteCategoryCommand = _mapper.Map<DeleteCategoryCommand>(categoryViewModel);

            return await _mediator.Send(deleteCategoryCommand);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(
                await _categoryRepository.GetAll());
        }

        public async Task<ValidationResult> Update(CategoryViewModel categoryViewModel)
        {
            UpdateCategoryCommand updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(categoryViewModel);

            return await _mediator.Send(updateCategoryCommand);
        }
    }
}
