using Domain.HeroMicroservice.Services.Interfaces;
using HeroMicroservice.DTO;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebAPIMock.Message;

namespace WebAPIMock.Requests
{
    public class ProcessoRequisicao : IProcessoRequisicao
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ProcessoRequisicao(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void ProcessaHeroRequest(string mensagemParaConsumir)
        {
            using var scope = _scopeFactory.CreateScope();

            var heroService = scope.ServiceProvider.GetRequiredService<IHeroService>();
            var messageService = scope.ServiceProvider.GetRequiredService<IMessageProducer>();

            var hero = JsonConvert.DeserializeObject<HeroDTO>(mensagemParaConsumir);

            var result = heroService.InsertRecord(hero);

            // Se der erro dispara uma msg
            if (!result) {
                messageService.SendMessage("falha no insert.");
            }
            else
            {
                messageService.SendMessage("Insert com sucesso!.");
            }
        }

    }
}
