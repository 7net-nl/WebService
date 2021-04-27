using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.UI.WebUI.Areas.Admin.Models
{
    public static class SeedHelperExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
           

            builder.Entity<MyUsers>().HasData(SampleData.Users);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "admin"
            });

            


           
        }
    }
}
