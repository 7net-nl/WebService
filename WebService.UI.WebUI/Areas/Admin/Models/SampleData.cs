using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.UI.WebUI.Areas.Admin.Models
{
    public static class SampleData
    {
        public static MyUsers Users { get; set; } = new MyUsers
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "test@yahoo.com",
            NormalizedUserName = "test@yahoo.com".ToUpper(),
            Email = "test@yahoo.com",
            NormalizedEmail = "test@yahoo.com".ToUpper(),
            EmailConfirmed = true,
            LockoutEnabled = false,
            
            SecurityStamp = Guid.NewGuid().ToString(),
            PasswordHash = new PasswordHasher<MyUsers>().HashPassword(Users,"A@a123456")
        };
    }
}
