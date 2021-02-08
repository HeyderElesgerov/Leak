using AutoMapper;
using Leak.Application.ViewModels.Blog;
using Leak.Application.ViewModels.Category;
using Leak.Application.ViewModels.Url;
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

            CreateMap<Url, UrlViewModel>()
                .ConstructUsing(u => new UrlViewModel(u.Id, u.Path));

            CreateMap<Blog, BlogViewModel>()
                .ConstructUsing(b => new BlogViewModel(
                    b.Id, b.Title, new UrlViewModel(b.UrlId, b.Url.Path)));
        }
    }
}
