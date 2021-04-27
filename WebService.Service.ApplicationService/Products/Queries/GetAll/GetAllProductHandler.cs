using AutoMapper;
using WebService.Domain.Contract.Repositories;
using WebService.Domain.Entities;
using WebService.Service.ApplicationService.Common;
using WebService.Service.ApplicationService.Products.Command.Create;
using WebService.Service.ApplicationService.Products.Queries.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebService.Service.ApplicationService.Products.Queries.GetAll
{
    public class GetAllProductHandler : CommandAndQueriesBase<GetAllProductRequest, GetAllProductRequest, IProductRepository,List<Product>,List<GetProductRequest>>
    {
        public GetAllProductHandler(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<GetAllProductRequest> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            Entity = repository.GetAll(request.currentpage, request.CountOnPage);
            request.Products = mapper.Map<List<Product>, List<CreateProductRequest>>(Entity);
            return request;
        }
    }
}
