using CnetCore.Domain.Contract.Interfaces;
using CnetCore.Domain.Contract.Repositories;
using CnetCore.Infrascture.DataBase.EF;
using CnetCore.Infrascture.DataBase.EF.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CnetCore.Infrascture.DataBase.Common
{
    public static class InfrasctureExtenstion
    {
        public static void ServiceInfrascture(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IDbContext, AppDbContext>();
            // services.AddSingleton(typeof(IDbSet<>), typeof(MyDbSet<>));
            services.AddSingleton(typeof(IDbSet<>), typeof(FactoryDbSet<>));
            // services.AddDbContext<AppDbContext>(c => c.UseSqlServer(configuration.GetConnectionString("default")));
            //services.AddDbContext<AppDbContext>(c => c.UseInMemoryDatabase("CnetCoreDb",d=>configuration.GetConnectionString("default")));
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
        }
    }
}
