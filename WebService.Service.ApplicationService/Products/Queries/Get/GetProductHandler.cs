using AutoMapper;
using WebService.Domain.Contract.Repositories;
using WebService.Domain.Entities;
using WebService.Service.ApplicationService.Common;
using WebService.Service.ApplicationService.Products.Command.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebService.Service.ApplicationService.Products.Queries.Get
{
    public class GetProductHandler : CommandAndQueriesBase<GetProductRequest, CreateProductRequest, IProductRepository,Product,CreateProductRequest>
    {
        public GetProductHandler(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<CreateProductRequest> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            Entity = repository.Find(request.Customer, request.SiteName, request.SiteUrl);
            EntityDto = mapper.Map<Product,CreateProductRequest>(Entity);
            return EntityDto;
            
        }
    }
}
