using WebService.Domain.Contract.Interfaces;
using WebService.Domain.Contract.Repositories;
using WebService.Domain.Entities;
using WebService.Infrascture.Common;
using WebService.Infrascture.DataBase.Fake;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WebService.Infrascture.DataBase.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
    {
        public ProductRepository(FactoryContext context) : base(context)
        {
        }

        public override IQueryable<Product> Queries()
        {
            return context.Set<Product>().Include(c => c.Services).Include(c => c.Tags).Include(c => c.Category).Include(c => c.Images).OrderBy(c=>c.Customer);
        }

        public Product Find(string Customer="",string SiteName ="",string SiteUrl="")
        {
            return Queries().Where(c => c.Customer.ToLower() == Customer.ToLower() & c.SiteName.ToLower() == SiteName.ToLower() & c.SiteUrl == SiteUrl).LastOrDefault();
        }

    }
}
