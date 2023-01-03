using Domain.HeroMicroservice.Services.Interfaces;
using HeroMicroservice.DTO;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Threading.Tasks;
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

        public async Task ProcessaHeroRequest(string mensagemParaConsumir)
        {
            using var scope = _scopeFactory.CreateScope();

            var heroService = scope.ServiceProvider.GetRequiredService<IHeroService>();

            var hero = JsonConvert.DeserializeObject<HeroDTO>(mensagemParaConsumir);

            var result = await heroService.InsertRecord(hero);

        }

    }
}
