using CnetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CnetCore.Infrascture.DataBase.EF
{
    public static class SeedExtension
    {
        public static void SeedHelper(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasData(SampleData.Products());
        }
    }
}
