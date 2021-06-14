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
    [Route("photos")]
    public class PhotoController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [Authorize]
        public string InsertPhotos() => String.Format("O usuário pode inserir fotos em um album");

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public string VisualizePhotos() => String.Format("Qualquer um pode visualizar as fotos");
    }
}
