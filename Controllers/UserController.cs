using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Desafio.Services;
using Desafio.Repositories;
using Desafio.Models;

namespace Desafio.Controllers
{
    [Route("user")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "admin")]
        public string admin() => "Administrador";

        
        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,admin")]
        public string Employee() => "Funcionário";

    }
}
