using Domain.HeroMicroservice.Services;
using Domain.HeroMicroservice.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIMock.CrossCutting.IOC.Modules
{
    public class ServiceModule
    {
        public static void SetModules(IServiceCollection container)
        {
            container.AddScoped<IHeroService, HeroService>();


        }
    }
}
