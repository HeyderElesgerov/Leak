using AutoMapper;
using Leak.Application.ViewModels.Blog;
using Leak.Application.ViewModels.Category;
using Leak.Application.ViewModels.Post;
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
                .ConstructUsing(b => new BlogViewModel(b.Id, b.Title));

            CreateMap<Post, PostViewModel>()
                .ConstructUsing(p => new PostViewModel(p.Id, p.Title, p.Content, p.IsActive, p.HeaderPhotoFilePath, p.Blog, p.Category));
        }
    }
}
