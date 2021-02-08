using AutoMapper;
using FluentValidation.Results;
using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Url;
using Leak.Domain.Commands.Url;
using Leak.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.Services
{
    public class UrlService : IUrlService
    {
        private IMapper _mapper;
        private IMediator _mediator;
        private IUrlRepository _urlRepository;

        public UrlService(
            IMapper mapper,
            IMediator mediator,
            IUrlRepository urlRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _urlRepository = urlRepository;
        }

        public Task<ValidationResult> Add(UrlViewModel urlViewModel)
        {
            CreateUrlCommand createUrlCommand = 
                _mapper.Map<CreateUrlCommand>(urlViewModel);

            return _mediator.Send(createUrlCommand);
        }

        public Task<ValidationResult> Delete(UrlViewModel urlViewModel)
        {
            DeleteUrlCommand deleteUrlCommand =
                _mapper.Map<DeleteUrlCommand>(urlViewModel);

            return _mediator.Send(deleteUrlCommand);
        }

        public Task<UrlViewModel> Get(int id)
        {
            return Task.FromResult(
                _mapper.Map<UrlViewModel>(_urlRepository.Find(id)));
        }

        public Task<ValidationResult> Update(UrlViewModel urlViewModel)
        {
            UpdateUrlCommand updateUrlCommand =
                _mapper.Map<UpdateUrlCommand>(urlViewModel);

            return _mediator.Send(updateUrlCommand);
        }
    }
}
