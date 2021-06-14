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
    [Route("post")]
    public class PostController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [Authorize]
        public string InsertPosts() => String.Format("Onde o usuário pode cadastrar posts");

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public string VisualizePosts() => String.Format("Onde qualquer usuário pode visualizar os posts");
    }
}
