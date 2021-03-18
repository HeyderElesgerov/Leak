using System;

namespace Leak.Application.ViewModels.SentPost
{
    public class CreateSentPostViewModel
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string HeaderPhotoPath { get; private set; }
        public int BlogId { get; private set; }
        public int CategoryId { get; private set; }
        public Guid AuthorId { get; set; }

        public CreateSentPostViewModel(
            string title, string content, string headerPhotoPath, int blogId, int categoryId, Guid authorId)
        {
            Title = title;
            Content = content;
            HeaderPhotoPath = headerPhotoPath;
            BlogId = blogId;
            CategoryId = categoryId;
            AuthorId = authorId;
        }
    }
}
