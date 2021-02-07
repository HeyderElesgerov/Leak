using AutoMapper;
using Leak.Application.ViewModels.Category;
using Leak.Domain.Commands.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryViewModel, CreateCategoryCommand>()
                .ConvertUsing(c => new CreateCategoryCommand(c.Title));

            CreateMap<CategoryViewModel, UpdateCategoryCommand>()
                .ConvertUsing(c => new UpdateCategoryCommand(c.Id, c.Title));

            CreateMap<CategoryViewModel, DeleteCategoryCommand>()
                .ConvertUsing(c => new DeleteCategoryCommand(c.Id));
        }
    }
}
