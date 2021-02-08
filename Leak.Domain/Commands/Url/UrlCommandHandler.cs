using FluentValidation.Results;
using Leak.Domain.Core.Command;
using Leak.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Url
{
    class UrlCommandHandler :
        CommandHandler,
        IRequestHandler<CreateUrlCommand, ValidationResult>,
        IRequestHandler<DeleteUrlCommand, ValidationResult>,
        IRequestHandler<UpdateUrlCommand, ValidationResult>
    {
        private readonly IUrlRepository _urlRepository;

        public UrlCommandHandler(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }

        public async Task<ValidationResult> Handle(CreateUrlCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            await _urlRepository.Add(new Models.Url(request.Path));
            await _urlRepository.Commit();

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(DeleteUrlCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var url = _urlRepository.Find(request.Id);

            if(url == null)
            {
                AddError("Url not found");
            }
            else
            {
                await _urlRepository.Delete(url);
                await _urlRepository.Commit();
            }

            return ValidationResult;
        }

        public async Task<ValidationResult> Handle(UpdateUrlCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var url = _urlRepository.Find(request.Id);

            if (url == null)
            {
                AddError("Url not found");
            }
            else
            {
                url.Path = request.Path;
                _urlRepository.Update(url);
                await _urlRepository.Commit();
            }

            return ValidationResult;
        }
    }
}
