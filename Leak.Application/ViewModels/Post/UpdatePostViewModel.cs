namespace Leak.Application.ViewModels.Post
{
    public class UpdatePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

        public UpdatePostViewModel(
            int id, string title, string content, int blogId, int categoryId, bool isActive)
        {
            Id = id;
            Title = title;
            Content = content;
            BlogId = blogId;
            CategoryId = categoryId;
            IsActive = isActive;
        }
    }
}
