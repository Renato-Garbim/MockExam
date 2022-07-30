using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ClientHub _hub;

        public HeroController(IHeroAppService service)
        {
            _service = service;
            _hub = new ClientHub();

        }

        [HttpGet]
        public IEnumerable<HeroDTO> Get()
        {
            return _service.ObterTodos();
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<HeroDTO>> Post(HeroDTO dados)
        {
            _service.AdicionarOuAtualizar(dados);

            Console.WriteLine('Novo Registro Gerado no Banco.');

            await _hub.SendMessage("Novo Registro Gerado no Banco.");

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

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero =  _service.Remover(id);
            return NoContent();
        }
    }
}
