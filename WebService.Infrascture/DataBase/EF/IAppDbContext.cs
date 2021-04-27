using WebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebService.Infrascture.DataBase.EF
{
    public interface IAppDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<Tag> Tags { get; set; }
    }
}