using WebService.Service.ApplicationService.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Service.ApplicationService.Products.Queries.TotalPage
{
    public class GetProductTotalPageRequest : IRequest<short>
    {
        public short CountOnPage { get; set; }
    }
}
