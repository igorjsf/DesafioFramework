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
    [Route("album")]
    public class AlbumController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [Authorize]
        public string CreateAlbum() => String.Format("O usuário pode criar um novo album");

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public string VisualizeAlbum() => String.Format("Qualquer um pode visualizá-lo");
    }
}
