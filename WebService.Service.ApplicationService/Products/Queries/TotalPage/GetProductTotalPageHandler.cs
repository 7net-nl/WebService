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

namespace WebService.Service.ApplicationService.Products.Queries.TotalPage
{
    public class GetProductTotalPageHandler : CommandAndQueriesBase<GetProductTotalPageRequest,short,IProductRepository,Product,short>
    {
        public GetProductTotalPageHandler(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async override Task<short> Handle(GetProductTotalPageRequest request, CancellationToken cancellationToken)
        {
            return repository.TotalPage(request.CountOnPage);
        }
    }
}
