namespace Leak.Application.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        public string Title { get; private set; }

        public CreateCategoryViewModel(string title)
        {
            Title = title;
        }
    }
}
