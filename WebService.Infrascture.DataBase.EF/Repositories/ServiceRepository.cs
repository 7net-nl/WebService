using CnetCore.Domain.Contract.Interfaces;
using CnetCore.Domain.Contract.Repositories;
using CnetCore.Domain.Entities;
using CnetCore.Infrascture.DataBase.Fake;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnetCore.Infrascture.DataBase.EF.Repositories
{
    public class ServiceRepository : BaseRepository<Service, Guid>, IServiceRepository
    {
        public ServiceRepository(IDbContext context) : base(context)
        {
        }
    }
}
