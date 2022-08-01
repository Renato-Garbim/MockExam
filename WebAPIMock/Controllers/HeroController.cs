using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MockApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIMock.Hubs;
using WebAPIMock.ViewModel;

namespace WebAPIMock.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroAppService _service;
        private readonly IHubContext<ClientHub> _hubContext;

        public HeroController(IHeroAppService service, IHubContext<ClientHub> hubContext)
        {
            _service = service;
            _hubContext = hubContext;

        }

        [HttpGet]
        public async Task<IEnumerable<HeroDTO>> Get()
        {
            var registros = _service.ObterTodos();
            var quantidadeRegistrosNaBase = QuantidadeHeroisEncontrados(registros);            

            await _hubContext.Clients.All.SendAsync("Send", $"Foram recuperados {quantidadeRegistrosNaBase} herói(s) da base.");

            return registros;
        }

        private int QuantidadeHeroisEncontrados(IEnumerable<HeroDTO> listaRecuperada)
        {
            return listaRecuperada.Count();
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<HeroDTO>> Post(HeroDTO dados)
        {
            _service.AdicionarOuAtualizar(dados);
            
            await _hubContext.Clients.All.SendAsync("Send", $"Novo Herói {dados.Name} adicionado a base.");

            return Ok();
        }


        // GET: api/Hero/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeroDTO>> Get(int id)
        {
            var hero = _service.ObterPorId(id);

            if (hero == null)
            {
                return NotFound();
            }

            return hero;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHero(int id, HeroDTO item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _service.AdicionarOuAtualizar(item);

            await _hubContext.Clients.All.SendAsync("Send", $"Herói {item.Name} atualizado na base.");

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero =  _service.Remover(id);

            await _hubContext.Clients.All.SendAsync("Send", $"Herói {id} removido da base.");

            return NoContent();
        }
    }
}
