using Microsoft.Extensions.DependencyInjection;
using Repositorio.Repository;
using Repositorio.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIMock.CrossCutting.IOC.Modules
{
    public class RepositoryModule
    {
        public static void SetModules(IServiceCollection container)
        {

            container.AddScoped<IHeroRepository, HeroRepository>();

        }
    }
}
