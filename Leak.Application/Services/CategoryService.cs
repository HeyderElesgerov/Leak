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

        public async Task<ValidationResult> Add(CreateCategoryViewModel createCategoryViewModel)
        {
            CreateCategoryCommand createCategoryCommand = 
                _mapper.Map<CreateCategoryCommand>(createCategoryViewModel);
            return await _mediator.Send(createCategoryCommand);
        }

        public async Task<ValidationResult> Delete(int id)
        {
            DeleteCategoryCommand deleteCategoryCommand = new DeleteCategoryCommand(id);
            return await _mediator.Send(deleteCategoryCommand);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(
                await _categoryRepository.GetAll());
        }

        public CategoryViewModel GetCategory(int id)
        {
            return _mapper.Map<CategoryViewModel>(_categoryRepository.Find(id));
        }

        public async Task<ValidationResult> Update(UpdateCategoryViewModel updateCategoryViewModel)
        {
            UpdateCategoryCommand updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(updateCategoryViewModel);
            return await _mediator.Send(updateCategoryCommand);
        }
    }
}
