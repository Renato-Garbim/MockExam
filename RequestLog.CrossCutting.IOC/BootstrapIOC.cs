using Microsoft.Extensions.DependencyInjection;
using RequestLog.CrossCutting.IOC.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestLog.CrossCutting.IOC
{
    public class BootstrapIOC
    {
        public static void RegisterServices(IServiceCollection container)
        {
            //HandleModule.SetModules(container);
            RepositoryModule.SetModules(container);
            ServiceModule.SetModules(container);
        }
    }
}
