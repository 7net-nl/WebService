using WebService.Domain.Contract.Interfaces;
using WebService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Domain.Contract.Repositories
{
    public interface IProductRepository : IBaseRepository<Product,Guid>  
    {
        Product Find(string Customer = "", string SiteName = "", string SiteUrl="");
    }
}
