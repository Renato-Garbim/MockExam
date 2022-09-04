using AutoMapper;
using HeroMicroservice.AutoMapper;
using HeroMicroservice.CrossCutting.IOC;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMock.StartupConfig
{
    public static class ServiceCollectionRegisterServices
    {
        public static IServiceCollection StartRegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BootstraperAutoMapper).Assembly);

            // Core
            Bootstraper.RegisterServices(services);
           


            return services;
        }

       
    }
}
