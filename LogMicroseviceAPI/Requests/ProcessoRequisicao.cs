using Newtonsoft.Json;
using RequestLog.Services.Interfaces;
using RequestLog.Services.Models;

namespace WebAPIMock.Requests
{
    public class ProcessoRequisicao : IProcessoRequisicao
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public ProcessoRequisicao(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task ProcessaLogRequest(string mensagemParaConsumir)
        {
            using var scope = _scopeFactory.CreateScope();

            var heroLogService = scope.ServiceProvider.GetRequiredService<IHeroLogService>();

            var dto = new HeroLogDTO()
            {                
                Operation = "insert register",
                RequestBody = mensagemParaConsumir,
                DateInsert = DateTime.Now,
                DateUpdate = DateTime.Now
            };

            var result = await heroLogService.InsertRecord(dto);

        }

    }
}
