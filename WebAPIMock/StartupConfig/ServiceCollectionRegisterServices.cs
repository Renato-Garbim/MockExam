using HeroMicroservice.AutoMapper;
using HeroMicroservice.CrossCutting.IOC;
using Microsoft.Extensions.DependencyInjection;
using WebAPIMock.Message;
using WebAPIMock.Requests;

namespace WebAPIMock.StartupConfig
{
    public static class ServiceCollectionRegisterServices
    {
        public static IServiceCollection StartRegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BootstraperAutoMapper).Assembly);

            // Core
            Bootstraper.RegisterServices(services);
            services.AddSingleton<IMessageProducer, MessageProducer>();
            services.AddSingleton<IProcessoRequisicao, ProcessoRequisicao>();
            services.AddHostedService<MessageReceiver>();
            
            return services;
        }

       
    }
}
