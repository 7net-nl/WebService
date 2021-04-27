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

namespace WebService.Service.ApplicationService.Products.Command.Delete
{
    public class DeleteProductHandler : CommandAndQueriesBase<DeleteProductRequest,string,IProductRepository,Product,string>
    {
        public DeleteProductHandler(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<string> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            Entity = repository.Find(request.ProductRequest.Customer, request.ProductRequest.SiteName, request.ProductRequest.SiteUrl);
            return repository.Delete(Entity);

        }
    }
}
