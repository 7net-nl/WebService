using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Domain.Entities
{
    public class Tag : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public Guid Product_ID { get; set; }
    }
}
