using FluentValidation.Results;
using Leak.Application.ViewModels.SentPost;
using Leak.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Leak.Application.Interfaces
{
    public interface ISentPostService
    {
        Task<SentPostViewModel> GetById(int id, params Expression<Func<SentPost, object>>[] includes);

        Task<ValidationResult> Add(CreateSentPostViewModel createPostViewModel);

        Task<ValidationResult> Delete(int id);

        Task<ValidationResult> Approve(int id);
    }
}
