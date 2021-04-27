using AutoMapper;
using WebService.Domain.Contract.Repositories;
using WebService.Domain.Entities;
using WebService.Service.ApplicationService.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebService.Service.ApplicationService.Products.Command.Create
{
    public class CreateProductRequestHandler : CommandAndQueriesBase<CreateProductRequest, string, IProductRepository, Product, string>
    {
        public CreateProductRequestHandler(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<string> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Entity = mapper.Map<CreateProductRequest, Product>(request);
            return repository.Add(Entity);
        }
    }
}
