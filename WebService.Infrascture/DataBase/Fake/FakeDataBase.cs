using WebService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebService.Infrascture.DataBase.Fake
{
    public static class FakeDataBase<TEntity> where TEntity : class
    {
        private static Dictionary<Type, List<TEntity>> Entities { get; set; } = new Dictionary<Type, List<TEntity>>();

        public static List<TEntity> List(Type type)
        {
            if (!Entities.ContainsKey(type)) Entities.Add(type, new List<TEntity>());

            return Entities[type];
        }

        public static void Add(Type type, TEntity entity)
        {
            
            List(type).Add(entity);
         

        }

        public static void Update(Type type, TEntity entity)
        {
            List(type).Where(c => c.GetType().GetProperty("Customer").GetValue(c) == entity.GetType().GetProperty("Customer").GetValue(entity)).All(d => { d = entity; return true; });
        }

        public static void Remove(Type type, TEntity entity)
        {
            List(type).Remove(entity);
        }

        public static TEntity Find(Type type, object key)
        {
            return List(type).Find(c => c.GetType().GetProperty("ID").GetValue(c) == key);
        }


    }
}
