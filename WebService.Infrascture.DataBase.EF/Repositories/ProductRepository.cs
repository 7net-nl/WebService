using CnetCore.Domain.Contract.Interfaces;
using CnetCore.Domain.Contract.Repositories;
using CnetCore.Domain.Entities;
using CnetCore.Infrascture.DataBase.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CnetCore.Infrascture.DataBase.EF.Repositories
{
    public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
    {
        public ProductRepository(IDbContext context) : base(context)
        {
            
        }

       

    }
}
