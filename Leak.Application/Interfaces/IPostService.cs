using FluentValidation.Results;
using Leak.Application.ViewModels.Post;
using Leak.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leak.Application.Interfaces
{
    public interface IPostService
    {
        Task<PostViewModel> GetById(int id, params Expression<Func<Post, object>>[] includes);
        IEnumerable<PostViewModel> GetLatestPosts(int count, params Expression<Func<Post, object>>[] includes);
        Task<IEnumerable<PostViewModel>> GetPostsByBlog(int blogId, params Expression<Func<Post, object>>[] includes);
        IEnumerable<PostViewModel> GetPaginatedPosts(int page, int elementCountPerPage, Expression<Func<Post, bool>> predicate, params Expression<Func<Post, object>>[] includes);
        Task<ValidationResult> Add(CreatePostViewModel createPostViewModel);
        Task<ValidationResult> Update(UpdatePostViewModel updatePostViewModel);
        Task<ValidationResult> Delete(int id);
        Task<ValidationResult> IncreaseReadingCount(int id);
    }
}
