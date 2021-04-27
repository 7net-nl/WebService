using WebService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Domain.Contract.Repositories
{
    public interface IServiceRepository : IBaseRepository<Service,Guid>
    {
    }
}
