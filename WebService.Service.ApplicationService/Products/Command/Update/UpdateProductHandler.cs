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

namespace WebService.Service.ApplicationService.Products.Command.Update
{
    public class UpdateProductHandler : CommandAndQueriesBase<UpdateProductRequest, string, IProductRepository, Product, string>
    {
        public UpdateProductHandler(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public override async Task<string> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            Entity = repository.Find(request.ProductBefore.Customer, request.ProductBefore.SiteName, request.ProductBefore.SiteUrl);
            var model = mapper.Map<CreateProductRequest, Product>(request.Product);
            Entity.Category = model.Category;
            Entity.Customer = model.Customer;
            Entity.Description = model.Description;
            Entity.EndDate = model.EndDate;
            Entity.Images = model.Images;
            Entity.Services = model.Services;
            Entity.SiteName = model.SiteName;
            Entity.SiteUrl = model.SiteUrl;
            Entity.StartDate = model.StartDate;
            Entity.Tags = model.Tags;
            return repository.Update(Entity);
        }
    }
}
