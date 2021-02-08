using FluentValidation.Results;
using Leak.Application.ViewModels.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.Interfaces
{
    public interface IUrlService
    {
        Task<UrlViewModel> Get(int id);

        Task<ValidationResult> Add(UrlViewModel urlViewModel);

        Task<ValidationResult> Delete(UrlViewModel urlViewModel);

        Task<ValidationResult> Update(UrlViewModel urlViewModel);
    }
}
