using System;

namespace WebService.Domain.Entities
{
    public abstract class BaseEntity<TPrimaryKey>
    {
        public TPrimaryKey ID { get; set; }
        public bool Delete { get; set; }
    }
}
