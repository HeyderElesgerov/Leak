using AutoMapper;
using Leak.Application.ViewModels.Category;
using Leak.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Leak.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ConstructUsing(c => new CategoryViewModel(c.Id, c.Title));
        }
    }
}
