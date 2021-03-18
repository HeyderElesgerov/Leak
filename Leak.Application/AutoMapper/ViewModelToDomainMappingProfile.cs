using AutoMapper;
using Leak.Application.ViewModels.Blog;
using Leak.Application.ViewModels.Category;
using Leak.Application.ViewModels.Post;
using Leak.Application.ViewModels.SentPost;
using Leak.Domain.Commands.Blog;
using Leak.Domain.Commands.Category;
using Leak.Domain.Commands.Post;
using Leak.Domain.Commands.SentPost;

namespace Leak.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Category
            CreateMap<CreateCategoryViewModel, CreateCategoryCommand>()
                .ConvertUsing(c => new CreateCategoryCommand(c.Title));
            CreateMap<UpdateCategoryViewModel, UpdateCategoryCommand>()
                .ConvertUsing(c => new UpdateCategoryCommand(c.Id, c.Title));

            //Blog
            CreateMap<CreateBlogViewModel, CreateBlogCommand>()
                .ConvertUsing(b => new CreateBlogCommand(b.Title));
            CreateMap<UpdateBlogViewModel, UpdateBlogCommand>()
                .ConvertUsing(b => new UpdateBlogCommand(b.Id, b.Title));

            //Post
            CreateMap<CreatePostViewModel, CreatePostCommand>();
            CreateMap<UpdatePostViewModel, UpdatePostCommand>();

            //SentPost
            CreateMap<CreateSentPostViewModel, CreateSentPostCommand>();
        }
    }
}
