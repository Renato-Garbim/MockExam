using BackForFrontAngular.Message;
using BackForFrontAngular.Models.Hero;
using BackForFrontAngular.Models.Notifications;
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
                
        public HeroController(IMessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
            
        }

        [HttpPost("AddHero")]
        public async Task<ActionResult> Registrar(HeroViewModel heroForAdd)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
            
            var response = await _messageProducer.SendMessageExchange(heroForAdd);

            NotificationModel notification = new NotificationModel();
            notification.result = true;

            string msg;

            foreach(var result in response)
            {
                msg = result.ToString();
                notification.MsgReturn = msg + "," + notification.MsgReturn;
            }
            

                                            
            return Ok(notification);
        }

    }
}
