using WebService.Domain.Contract.Interfaces;
using WebService.Domain.Entities;
using WebService.Infrascture.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WebService.Infrascture.DataBase.Fake
{
    public class FakeDbSet<TEntity> : IEnumerable<TEntity> where TEntity : class
    {

        public string Add(TEntity entity)
        {
            FakeDataBase<TEntity>.Add(typeof(TEntity), entity);
           return $"{typeof(TEntity)} Added";
        }
        public string Update(TEntity entity)
        {
            FakeDataBase<TEntity>.Update(typeof(TEntity), entity);
            return $"{typeof(TEntity)} Update";
        }
        public string Remove(TEntity entity)
        {
            FakeDataBase<TEntity>.Remove(typeof(TEntity), entity);
            return $"{typeof(TEntity)} Remove";
        }
        public TEntity Find(object Key)=>  FakeDataBase<TEntity>.Find(typeof(TEntity),Key);
        
        public IEnumerator<TEntity> GetEnumerator()=> FakeDataBase<TEntity>.List(typeof(TEntity)).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()=> FakeDataBase<TEntity>.List(typeof(TEntity)).GetEnumerator();
       
    }
}