namespace Leak.Application.ViewModels.Post
{
    public class CreatePostViewModel
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string HeaderPhotoPath { get; private set; }
        public int BlogId { get; private set; }
        public int CategoryId { get; private set; }
        public bool IsActive { get; private set; }

        public CreatePostViewModel(
            string title, string content, string headerPhotoPath, int blogId, int categoryId, bool isActive)
        {
            Title = title;
            Content = content;
            HeaderPhotoPath = headerPhotoPath;
            BlogId = blogId;
            CategoryId = categoryId;
            IsActive = isActive;
        }
    }
}
