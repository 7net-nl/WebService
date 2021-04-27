using WebService.Service.ApplicationService.Common;
using WebService.Service.ApplicationService.Products.Command.Create;
using WebService.Service.ApplicationService.Products.Queries.Get;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Service.ApplicationService.Products.Queries.GetAll
{
    public class GetAllProductRequest : IRequest<GetAllProductRequest>
    {
        public short currentpage { get; set; }
        public short CountOnPage { get; set; }
        public List<CreateProductRequest> Products { get; set; }
    }
}
