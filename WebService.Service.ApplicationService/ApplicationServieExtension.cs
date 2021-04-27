using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentValidation;
using WebService.Domain.Contract.Interfaces;
using AutoMapper;
using WebService.Service.ApplicationService.Common;

namespace WebService.Service.ApplicationService
{
    public static class ApplicationServieExtension
    {
        public static void ServiceApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

           
        }
    }
}
