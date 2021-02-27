namespace Leak.Application.ViewModels.Category
{
    public class UpdateCategoryViewModel
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public UpdateCategoryViewModel(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
