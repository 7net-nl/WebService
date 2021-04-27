using WebService.Infrascture.DataBase.EF;
using WebService.Infrascture.DataBase.Fake;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Infrascture.Common
{
    public class FactoryContext : AppDbContext
    {
        public FactoryContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

      
    }
}
