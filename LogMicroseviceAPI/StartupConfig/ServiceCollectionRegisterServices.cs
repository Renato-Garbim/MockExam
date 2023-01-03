using LogMicroseviceAPI.MessageBroker;
using Microsoft.Extensions.DependencyInjection;
using RequestLog.AutoMapper;
using RequestLog.CrossCutting.IOC;
using WebAPIMock.Requests;

namespace LogMicroseviceAPI.StartupConfig
{
    public static class ServiceCollectionRegisterServices
    {
        public static IServiceCollection StartRegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BootstraperAutoMapper).Assembly);

            // Core
            BootstrapIOC.RegisterServices(services);
            services.AddSingleton<IProcessoRequisicao, ProcessoRequisicao>();
            services.AddHostedService<MessageReceiver>();

            return services;
        }


    }
}
