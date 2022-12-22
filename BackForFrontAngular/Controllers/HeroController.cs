using BackForFrontAngular.Message;
using BackForFrontAngular.Models.Hero;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace BackForFrontAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        const string URL = "https://localhost:5001/api/Hero"; // used only for GetData from the Microservice

        private readonly IMessageProducer _messageProducer;
        private readonly IMessageReceiver _messageReceiver;
        
        public HeroController(IMessageProducer messageProducer, IMessageReceiver messageReceiver)
        {
            _messageProducer = messageProducer;
            _messageReceiver = messageReceiver;
        }

        [HttpPost("AddHero")]
        public async Task<ActionResult> Registrar(HeroViewModel heroForAdd)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            _messageProducer.SendMessage(heroForAdd);

            var response = _messageReceiver.CheckQueu();

            return Ok(response);
        }

    }
}
