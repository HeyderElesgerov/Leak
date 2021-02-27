using Leak.Application.Utility;
using Leak.Application.ViewModels.Blog;
using Leak.Application.ViewModels.Category;

namespace Leak.Application.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string HeaderPhotoPath { get; set; }
        public bool IsActive { get; set; }
        public string Url { get; private set; }
        public CategoryViewModel Category { get; set; }
        public BlogViewModel Blog { get; set; }

        public PostViewModel(
            int id, string title, string content, bool isActive, string headerPhotoPath, Domain.Models.Blog blog = null, Domain.Models.Category category = null)
        {
            Id = id;
            Title = title;
            Content = content;
            HeaderPhotoPath = headerPhotoPath;
            IsActive = isActive;
            Url = ContentUrlGenerator.GenerateUrl(id, title);

            if(blog != null)
            {
                Blog = new BlogViewModel(blog.Id, blog.Title);
            }

            if(category != null)
            {
                Category = new CategoryViewModel(category.Id, category.Title);
            }
        }
    }
}
