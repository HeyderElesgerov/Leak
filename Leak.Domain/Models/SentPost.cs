using Leak.Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Models
{
    public class SentPost : BaseEntity<int>
    {
        public SentPost()
        {
        }

        public SentPost(string title, string content, string photoFileName, int blogId, int categoryId, AppUser appUser)
        {
            Title = title;
            Content = content;
            HeaderPhotoFilePath = photoFileName;
            BlogId = blogId;
            CategoryId = categoryId;
            Author = appUser;
            SentDate = DateTime.Now;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string HeaderPhotoFilePath { get; set; }

        public DateTime SentDate { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public AppUser Author { get; set; }

        public int? ApprovedPostId { get; set; }
        public Post ApprovedPost { get; set; }//when admin approves, SentPost -> Post 
    }
}
