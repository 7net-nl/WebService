using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebService.Service.ApplicationService.Common
{
    public abstract class CommandAndQueriesBase<TRequest,TRespons,TRepository,TEntity,TEntityDto> : IRequestHandler<TRequest,TRespons>
        where TRequest : IRequest<TRespons>
    {
        public readonly TRepository repository;
        public readonly IMapper mapper;
        public TEntity Entity { get; set; }
        public TEntityDto EntityDto { get; set; }
        public CommandAndQueriesBase(TRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public abstract Task<TRespons> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
