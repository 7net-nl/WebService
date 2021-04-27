using WebService.Domain.Entities;
using WebService.Service.ApplicationService.Common;
using WebService.Service.ApplicationService.Products.Command.Create;
using WebService.Service.ApplicationService.Products.Queries.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Service.ApplicationService.Products.Command.Update
{
    public class UpdateProductRequest : IRequest<string>
    {
        public GetProductRequest ProductBefore { get; set; }
        public CreateProductRequest Product { get; set; }
    }
}
