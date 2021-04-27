using WebService.Domain.Contract.Interfaces;
using WebService.Domain.Contract.Repositories;
using WebService.Domain.Entities;
using WebService.Infrascture.Common;
using WebService.Infrascture.DataBase.Fake;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Infrascture.DataBase.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(FactoryContext context) : base(context)
        {
        }
    }
}
