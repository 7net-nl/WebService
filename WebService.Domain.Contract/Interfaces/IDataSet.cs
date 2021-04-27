using WebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Domain.Contract.Interfaces
{
    public interface IDataSet
    {
        DbSet<Product> Products { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Tag> Tags { get; set; }
    }
}
