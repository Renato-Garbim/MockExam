using Microsoft.Extensions.DependencyInjection;
using RequestLogInfra.Interfaces;
using RequestLogInfra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestLog.CrossCutting.IOC.Modules
{
    public class RepositoryModule
    {
        public static void SetModules(IServiceCollection container)
        {

            container.AddScoped<IHeroLogRepository, HeroLogRepository>();

        }
    }
}
