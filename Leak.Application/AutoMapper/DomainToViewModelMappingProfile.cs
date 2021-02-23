using AutoMapper;
using Leak.Application.ViewModels.Blog;
using Leak.Application.ViewModels.Category;
using Leak.Domain.Models;

namespace Leak.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                .ConstructUsing(c => new CategoryViewModel(c.Id, c.Title));

            CreateMap<Blog, BlogViewModel>()
                .ConvertUsing(b => new BlogViewModel(b.Id, b.Title));
        }
    }
}
