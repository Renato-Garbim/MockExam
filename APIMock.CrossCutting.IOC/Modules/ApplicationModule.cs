using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIMock.CrossCutting.IOC.Modules
{
    public class ApplicationModule
    {
        public static void SetModules(IServiceCollection container)
        {

            container.AddScoped<IHeroAppService, HeroAppService>();


        }
    }
}
