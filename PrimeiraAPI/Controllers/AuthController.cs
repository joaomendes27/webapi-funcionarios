using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PrimeiraAPI.Domain.Models;
using PrimeiraAPI.Application.Services;


//Autenticacao Simplificada, em um cenario real utilizariamos senhas com hash

namespace PrimeiraAPI.Controllers
{

    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
             if (username == "joao" && password == "senhateste")
            {
                var token = TokenService.GenerateToken(new Domain.Models.FuncionarioAggregate.Funcionario());
                return Ok(token);
            }

            return BadRequest("Usuário ou senha incorretos!");
        }
    }
}
