namespace Leak.Application.ViewModels.Post
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string HeaderPhotoName { get; set; }
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public string UrlPath { get; set; }

        public CreatePostViewModel(
            string title, string content, string headerPhotoName, int blogId, int categoryId, bool isActive, string urlPath)
        {
            Title = title;
            Content = content;
            HeaderPhotoName = headerPhotoName;
            BlogId = blogId;
            CategoryId = categoryId;
            IsActive = isActive;
            UrlPath = urlPath;
        }
    }
}
