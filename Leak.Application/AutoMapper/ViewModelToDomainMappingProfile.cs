using AutoMapper;
using Leak.Application.ViewModels.Blog;
using Leak.Application.ViewModels.Category;
using Leak.Application.ViewModels.Url;
using Leak.Domain.Commands.Blog;
using Leak.Domain.Commands.Category;
using Leak.Domain.Commands.Url;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Category
            CreateMap<CategoryViewModel, CreateCategoryCommand>()
                .ConvertUsing(c => new CreateCategoryCommand(c.Title));
            CreateMap<CategoryViewModel, UpdateCategoryCommand>()
                .ConvertUsing(c => new UpdateCategoryCommand(c.Id, c.Title));
            CreateMap<CategoryViewModel, DeleteCategoryCommand>()
                .ConvertUsing(c => new DeleteCategoryCommand(c.Id));

            //Url
            CreateMap<UrlViewModel, CreateUrlCommand>()
                .ConvertUsing(u => new CreateUrlCommand(u.Path));
            CreateMap<UrlViewModel, UpdateUrlCommand>()
                .ConvertUsing(u => new UpdateUrlCommand(u.Id, u.Path));
            CreateMap<UrlViewModel, DeleteUrlCommand>()
                .ConvertUsing(u => new DeleteUrlCommand(u.Id));

            //Blog
            CreateMap<BlogViewModel, CreateBlogCommand>()
                .ConvertUsing(b => new CreateBlogCommand(b.Title, b.UrlPath));
            CreateMap<BlogViewModel, DeleteBlogCommand>()
                .ConvertUsing(b => new DeleteBlogCommand(b.Id));
        }
    }
}
