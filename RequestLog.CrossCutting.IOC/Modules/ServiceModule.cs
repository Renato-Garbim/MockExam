using Microsoft.Extensions.DependencyInjection;
using RequestLog.Services;
using RequestLog.Services.Interfaces;

namespace RequestLog.CrossCutting.IOC.Modules
{
    public class ServiceModule
    {
        public static void SetModules(IServiceCollection container)
        {
            container.AddScoped<IHeroLogService, HeroLogService>();


        }
    }
}
