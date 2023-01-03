using Microsoft.AspNetCore.Mvc;
using RequestLog.Services.Interfaces;
using RequestLog.Services.Models;

namespace LogMicroseviceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroLlogController : ControllerBase
    {
        private readonly IHeroLogService _heroLogService;

        public HeroLlogController(IHeroLogService heroLogService)
        {
            _heroLogService = heroLogService;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<HeroLogDTO>> Post(HeroLogDTO dados)
        {
            dados.DateInsert = DateTime.Now;
            dados.DateUpdate = DateTime.Now;

            await _heroLogService.InsertRecord(dados);

            //await _hubContext.Clients.All.SendAsync("Send", $"Novo Herói {dados.Name} adicionado a base.");

            return Ok();
        }





    }
}