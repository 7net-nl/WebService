using CnetCore.Domain.Contract.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CnetCore.Infrascture.Common
{
    public class FactoryDbSet<TEntity> : IDbSet<TEntity> where TEntity : class
    {
        public string Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public string Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(object Key)
        {
            throw new NotImplementedException();
        }

        public string Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public string AddRange(params TEntity[] entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
