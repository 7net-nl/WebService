using WebService.Service.ApplicationService.Common;
using WebService.Service.ApplicationService.Products.Queries.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Service.ApplicationService.Products.Command.Delete
{
    public class DeleteProductRequest : IRequest<string> 
    {
        public GetProductRequest ProductRequest { get; set; }
    }
}
