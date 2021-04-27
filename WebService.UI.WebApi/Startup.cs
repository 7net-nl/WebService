using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.Service.ApplicationService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FluentValidation.AspNetCore;
using WebService.Domain.Contract.Interfaces;
using System.Reflection;
using FluentValidation;
using WebService.Domain.Entities;
using WebService.Infrascture;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Firewall;
using System.Net;

namespace WebService.UI.WebApi
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
            services.AddControllers().AddFluentValidation();
            services.ServiceApplicationService();
            services.ServiceInfrascture(Configuration);
            services.AddApiVersioning(c=>
            {
                c.ReportApiVersions = true;
            });

            
          
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseFirewall(FirewallRulesEngine.DenyAllAccess().ExceptFromIPAddresses(new List<IPAddress> { IPAddress.Parse("1.1.1.1") }).ExceptFromLocalhost());

            app.UseAuthorization();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
