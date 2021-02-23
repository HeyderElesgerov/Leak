namespace Leak.Application.ViewModels.Blog
{
    public class UpdateBlogViewModel
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public UpdateBlogViewModel(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
