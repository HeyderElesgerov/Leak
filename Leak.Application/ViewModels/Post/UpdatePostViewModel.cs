using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.ViewModels.Post
{
    public class UpdatePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string HeaderPhotoName { get; set; }
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

        public UpdatePostViewModel(
            string title, string content, string headerPhotoName, int blogId, int categoryId, bool isActive)
        {
            Title = title;
            Content = content;
            HeaderPhotoName = headerPhotoName;
            BlogId = blogId;
            CategoryId = categoryId;
            IsActive = isActive;
        }
    }
}
