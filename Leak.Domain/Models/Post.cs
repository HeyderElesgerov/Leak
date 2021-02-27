using Leak.Domain.Core.Entity;
using System;

namespace Leak.Domain.Models
{
    public class Post : BaseEntity<int>
    {
        public Post()
        {
        }

        public Post(string title, string content, string photoFileName, bool isActive, int blogId, int categoryId)
        {
            Title = title;
            Content = content;
            HeaderPhotoFilePath = photoFileName;
            IsActive = isActive;
            BlogId = blogId;
            CategoryId = categoryId;
            DatePublished = DateTime.Now;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string HeaderPhotoFilePath { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int ReadingCount { get; set; }

        public DateTime DatePublished { get; set; }

        public bool IsActive { get; set; }

        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void ChangeContent(string content)
        {
            Content = content;
        }

        public void IncreaseReadingCount()
        {
            ReadingCount++;
        }

        public void ChangeActivityState()
        {
            IsActive = IsActive ? false : true;
        }
    }
}
