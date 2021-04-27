using WebService.Domain.Contract.Repositories;
using WebService.Infrascture.Common;
using WebService.Infrascture.DataBase.EF;
using WebService.Infrascture.DataBase.EF.Repositories;
using WebService.Infrascture.DataBase.Fake;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebService.Infrascture
{
    public static class InfrasctureExtenstion
    {
        public static void ServiceInfrascture(this IServiceCollection services,IConfiguration configuration)
        {

            //services.AddDbContext<AppDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("default")));
            services.AddDbContext<AppDbContext>(c => c.UseSqlite(configuration.GetConnectionString("defaultsqlite")));
            //.AddDbContext<AppDbContext>(c => c.UseInMemoryDatabase("WebServiceDb",d=>configuration.GetConnectionString("default")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped(typeof(DbSet<>), typeof(FakeDbSet<>));
            services.AddSingleton<FakeDbContext>();
            services.AddScoped<FactoryContext>();
            
            
            
        }
    }
}
