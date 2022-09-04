using Microsoft.Extensions.DependencyInjection;
using Repository.HeroMicroservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroMicroservice.CrossCutting.IOC.Modules
{
    public class RepositoryModule
    {
        public static void SetModules(IServiceCollection container)
        {

            container.AddScoped<IHeroRepository, HeroRepository>();

        }
    }
}
