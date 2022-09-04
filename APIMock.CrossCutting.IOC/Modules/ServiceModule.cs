using Domain.HeroMicroservice.Services;
using Domain.HeroMicroservice.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroMicroservice.CrossCutting.IOC.Modules
{
    public class ServiceModule
    {
        public static void SetModules(IServiceCollection container)
        {
            container.AddScoped<IHeroService, HeroService>();


        }
    }
}
