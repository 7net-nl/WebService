using WebService.Domain.Contract.Interfaces;
using WebService.Domain.Contract.Repositories;
using WebService.Domain.Entities;
using WebService.Infrascture.Common;
using WebService.Infrascture.DataBase.Fake;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Infrascture.DataBase.EF.Repositories
{
    public class ServiceRepository : BaseRepository<Service, Guid>, IServiceRepository
    {
        public ServiceRepository(FactoryContext context) : base(context)
        {
        }
    }
}
