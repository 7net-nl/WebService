using WebService.Domain.Entities;
using WebService.Infrascture.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebService.Infrascture.DataBase.EF
{
    public static class SeedExtension
    {
        public static void SeedHelper(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(SampleData.Products);
            modelBuilder.Entity<Tag>().HasData(SampleData.TagOnly);
            modelBuilder.Entity<Service>().HasData(SampleData.ServiceOnly);
            modelBuilder.Entity<Image>().HasData(SampleData.ImageOnly);
            modelBuilder.Entity<Category>().HasData(SampleData.CategoryOnly);

        }
    }
}
