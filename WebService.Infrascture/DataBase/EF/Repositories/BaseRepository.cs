using WebService.Domain.Contract.Interfaces;
using WebService.Domain.Contract.Repositories;
using WebService.Domain.Entities;
using WebService.Infrascture.Common;
using WebService.Infrascture.DataBase.Fake;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebService.Infrascture.DataBase.EF.Repositories
{
    public abstract class BaseRepository<TEntity,TPrimaryKey> :IBaseRepository<TEntity,TPrimaryKey>
        where TEntity : BaseEntity<TPrimaryKey>,new()
        where TPrimaryKey : struct
    {
        protected readonly FactoryContext context;

        public string Result { get; set; }
        public TEntity Entity { get; set; }
        public int TotalCount { get; set; }
        public double TotalPages { get; set; }

        public BaseRepository(FactoryContext context)
        {
            this.context = context;
        }
        public virtual string Add(TEntity entity)
        {
           Result = context.Set<TEntity>().Add(entity).State.ToString();
           context.SaveChanges();

            return Result;
        }

        public virtual string Update(TEntity entity)
        {
           Result = context.Set<TEntity>().Update(entity).State.ToString();
            context.SaveChanges();
            return Result;
        }

        public virtual TEntity Find(object key)
        {
            Entity = Queries().Where(c=>c.ID.Equals(key)).LastOrDefault();

            return Equals(Entity.ID,0) == false ? Entity : new TEntity();
        }

        public virtual string Delete(TEntity entity)
        {
            Entity = context.Set<TEntity>().Find(entity.ID);
            Entity.Delete = true;
            context.SaveChanges();
            Result = "Deleted";
            return Result;
        }

        public virtual List<TEntity> GetAll()
        {
            
            return context.Set<TEntity>().Count() > 0 ? Queries().ToList() : new List<TEntity>();
        }

        public virtual List<TEntity> GetAll(short CurrentPage = 1, short CountOnpage = 1)
        {
            TotalCount = context.Set<TEntity>().Count();

            return TotalCount > 0 ? Queries().Skip(CountOnpage * (CurrentPage - 1)).Take(CountOnpage).ToList() : new List<TEntity>();


        }

        public virtual IQueryable<TEntity> Queries()
        {
            return context.Set<TEntity>();
        }


        public short TotalPage(short CountOnpage = 1)
        {
            TotalCount = context.Set<TEntity>().Count();
            TotalPages = TotalCount / (double)CountOnpage;
            TotalPages = Math.Ceiling(TotalPages);
            return (short)TotalPages;
        }


      

       


    }
}
