using WebService.Domain.Contract.Interfaces;
using WebService.Domain.Entities;
using WebService.Infrascture.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Infrascture.DataBase.Fake
{
    public class FakeDbContext
    {
        public FakeDbContext()
        {

        }
        public FakeDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return new FakeDbSet<TEntity>();
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
