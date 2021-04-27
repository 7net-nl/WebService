using CnetCore.Domain.Contract.Interfaces;
using CnetCore.Domain.Contract.Repositories;
using CnetCore.Domain.Entities;
using CnetCore.Infrascture.DataBase.Fake;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CnetCore.Infrascture.DataBase.EF.Repositories
{
    public class BaseRepository<TEntity,TPrimaryKey> :IBaseRepository<TEntity,TPrimaryKey>
        where TEntity : BaseEntity<TPrimaryKey>,new()
        where TPrimaryKey : struct
    {
        protected readonly IDbContext context;

        public string Result { get; set; }
        public TEntity Entity { get; set; }
        public int TotalCount { get; set; }
        public double TotalPages { get; set; }

        public BaseRepository(IDbContext context)
        {
            this.context = context;
        }
        public virtual string Add(TEntity entity)
        {
           Result = context.Set<TEntity>().Add(entity);
           context.SaveChanges();

            return Result;
        }

        public virtual string Update(TEntity entity)
        {
           Result = context.Set<TEntity>().Update(entity).ToString();
            context.SaveChanges();
            return Result;
        }

        public virtual TEntity Find(TPrimaryKey key)
        {
            Entity = context.Set<TEntity>().Find(key);

            return Equals(Entity.ID,0) == false ? Entity : new TEntity();
        }

        public virtual string Delete(TEntity entity)
        {
            Result = context.Set<TEntity>().Remove(entity).ToString();
            context.SaveChanges();
            return Result;
        }

        public virtual List<TEntity> GetAll()
        {
            
            return context.Set<TEntity>().Count() > 0 ? context.Set<TEntity>().ToList() : new List<TEntity>();
        }

        public virtual List<TEntity> GetAll(short SelectPage = 1, short CountOnPage = 1)
        {
            TotalCount = context.Set<TEntity>().Count();

            return TotalCount > 0 ? context.Set<TEntity>().ToList().OrderBy(c => c.ID).Skip(SelectPage * (CountOnPage - 1)).Take(CountOnPage).ToList() : new List<TEntity>();


        }

        public double TotalPage(short CountOnPage = 1)
        {
            TotalCount = context.Set<TEntity>().Count();
            TotalPages = TotalCount / (double)CountOnPage;
            TotalPages = Math.Ceiling(TotalPages);
            return TotalPages;
        }

        
        
    }
}
