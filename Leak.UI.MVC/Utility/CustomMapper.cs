using Leak.Application.ViewModels.Blog;
using Leak.Application.ViewModels.Category;
using Leak.Application.ViewModels.Post;
using Leak.Application.ViewModels.SentPost;
using Leak.UI.MVC.Dtos.Blog;
using Leak.UI.MVC.Dtos.Category;
using Leak.UI.MVC.Dtos.Post;
using Leak.UI.MVC.Dtos.SentPost;

namespace Leak.UI.MVC.Utility
{
    public static class CustomMapper
    {
        public static CreateBlogViewModel GetCreateBlogViewModel(CreateBlogDto createBlogDto)
        {
            return new CreateBlogViewModel(createBlogDto.Title);
        }

        public static UpdateBlogViewModel GetUpdateBlogViewModel(UpdateBlogDto updateBlogDto)
        {
            return new UpdateBlogViewModel(updateBlogDto.Id, updateBlogDto.Title);
        }

        public static CreateCategoryViewModel GetCreateCategoryViewModel(CreateCategoryDto createCategoryDto)
        {
            return new CreateCategoryViewModel(createCategoryDto.Title);
        }

        public static UpdateCategoryViewModel GetUpdateCategoryViewModel(UpdateCategoryDto updateCategoryDto)
        {
            return new UpdateCategoryViewModel(updateCategoryDto.Id, updateCategoryDto.Title);
        }

        public static CreatePostViewModel GetCreatePostViewModel(CreatePostDto createPostDto, string photoPath)
        {
            return new CreatePostViewModel(
                createPostDto.Title,
                createPostDto.Content,
                photoPath,
                createPostDto.BlogId,
                createPostDto.CategoryId,
                createPostDto.IsActive,
                createPostDto.AuthorId);
        }

        public static CreateSentPostViewModel GetCreateSentPostViewModel(CreateSentPostDto createPostDto, string photoPath)
        {
            return new CreateSentPostViewModel(
                createPostDto.Title,
                createPostDto.Content,
                photoPath,
                createPostDto.BlogId,
                createPostDto.CategoryId,
                createPostDto.AuthorId);
        }

        public static UpdatePostViewModel GetUpdatePostViewModel(UpdatePostDto updatePostDto)
        {
            return new UpdatePostViewModel(
                updatePostDto.Id,
                updatePostDto.Title,
                updatePostDto.Content,
                updatePostDto.BlogId,
                updatePostDto.CategoryId,
                updatePostDto.IsActive);
        }
    }
}
