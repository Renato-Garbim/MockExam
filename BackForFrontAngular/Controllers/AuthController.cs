using BackForFrontAngular.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace BackForFrontAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        const string URL = "https://localhost:5001/api/Auth";

        public AuthController()
        {
        
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var client = new RestClient();
            var request = new RestRequest($"{URL}/registrar", Method.Post); 
            string body = JsonConvert.SerializeObject(registerUser);
            request.AddBody(body);

            var response = await client.PostAsync(request);

            return Ok(response.Content);
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            return Ok();

            //return BadRequest("Usuário ou Senha inválidos");

        }
    }
}
