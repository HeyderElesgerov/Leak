namespace Leak.Application.ViewModels.Blog
{
    public class CreateBlogViewModel
    {
        public string Title { get; private set; }

        public CreateBlogViewModel(string title)
        {
            Title = title;
        }
    }
}
