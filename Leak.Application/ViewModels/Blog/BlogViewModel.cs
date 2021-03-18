using Leak.Application.Utility;

namespace Leak.Application.ViewModels.Blog
{
    public class BlogViewModel
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Url { get; private set; }

        public BlogViewModel(int id, string title)
        {
            Id = id;
            Title = title;
            Url = ContentUrlGenerator.GenerateUrl(id, title);
        }
    }
}
