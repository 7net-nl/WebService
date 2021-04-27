using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebService.UI.WebUI.Areas.Admin.Models;
using WebService.UI.WebUI.Areas.Admin.Views.Product.Edit;
using WebService.UI.WebUI.Models;
using WebService.UI.WebUI.Models.Product;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;

namespace WebService.UI.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(c=>
            {
                
               
            }).AddRazorOptions(c =>
            {
                c.ViewLocationFormats.Add("/Views/Shared/Partial/{0}.cshtml");
                c.AreaViewLocationFormats.Add("/Areas/Admin/Views/Shared/Partials/{0}.cshtml");
                
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Admin/Profile/Login");
                opt.LogoutPath = new PathString("/Admin/Profile/LogOut");
                
            });
            
            services.AddSingleton<WebClient>(c => new WebClient());
            services.AddScoped<IGetProductApi, GetProductApi>();

            services.AddOptions();
            services.Configure<UrlApi>(Configuration.GetSection("UrlApi"));

            services.AddDbContext<MyIdentity>(c => c.UseSqlite(Configuration.GetConnectionString("Identitysqllite")));
            services.AddIdentity<MyUsers, IdentityRole>().AddEntityFrameworkStores<MyIdentity>().AddDefaultTokenProviders();
            //services.AddDbContext<MyIdentity>(c => c.UseSqlServer(Configuration.GetConnectionString("Identity")));
            
            

            services.AddServerSideBlazor();

            
       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Profile/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

          
            app.UseStatusCodePagesWithRedirects("/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default2",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
              
                endpoints.MapBlazorHub();
            });
        }
    }
}
