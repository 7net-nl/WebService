using WebService.Service.ApplicationService.Common;
using WebService.Service.ApplicationService.Products.Command.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Service.ApplicationService.Products.Queries.Get
{
    public class GetProductRequest : IRequest<CreateProductRequest> 
    {
        public string Customer { get; set; }
        public string SiteName { get; set; }
        public string SiteUrl { get; set; }
    }
}
