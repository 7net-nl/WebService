using WebService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using WebService.Domain.Contract.Interfaces;
using System.Linq.Expressions;

namespace WebService.Domain.Contract.Repositories
{
    public interface IBaseRepository<TEntity,TPrimaryKey>
        where TEntity : BaseEntity<TPrimaryKey>
        where TPrimaryKey : struct
    {
        string Add(TEntity entity);
        string Update(TEntity entity);
        TEntity Find(object key);
        string Delete(TEntity entity);
        List<TEntity> GetAll();
        List<TEntity> GetAll(short CurrentPage = 1, short CountOnpage = 1);
        short TotalPage(short CountOnpage = 1);
    }
}
