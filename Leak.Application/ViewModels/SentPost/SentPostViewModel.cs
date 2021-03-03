using Leak.Application.ViewModels.Blog;
using Leak.Application.ViewModels.Category;
using Leak.Application.ViewModels.Post;
using System;

namespace Leak.Application.ViewModels.SentPost
{
    public class SentPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string HeaderPhotoPath { get; set; }
        public string SentDate { get; set; }
        public CategoryViewModel Category { get; set; }
        public BlogViewModel Blog { get; set; }
        public bool IsApproved { get; set; }
        public PostViewModel ApprovedPost { get; set; }

        public SentPostViewModel(
            int id, string title, string content, string headerPhotoPath, DateTime sentDate, Domain.Models.Blog blog = null, Domain.Models.Category category = null, Domain.Models.Post approvedPost = null)
        {
            Id = id;
            Title = title;
            Content = content;
            HeaderPhotoPath = headerPhotoPath;;
            SentDate = sentDate.ToShortDateString();
            IsApproved = approvedPost != null;

            if (blog != null)
            {
                Blog = new BlogViewModel(blog.Id, blog.Title);
            }

            if (category != null)
            {
                Category = new CategoryViewModel(category.Id, category.Title);
            }

            if (approvedPost != null)
            {
                ApprovedPost = new PostViewModel(approvedPost.Id, approvedPost.Title, approvedPost.Content, approvedPost.IsActive, approvedPost.HeaderPhotoFilePath, approvedPost.DatePublished, approvedPost.Blog, approvedPost.Category);
            }
        }
    }
}
