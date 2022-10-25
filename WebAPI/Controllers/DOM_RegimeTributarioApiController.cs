using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    public class DOM_RegimeTributarioApiController : Controller
    {
        private readonly IDOM_RegimeTributario IDOM_RegimeTributario;
        public DOM_RegimeTributarioApiController(IDOM_RegimeTributario IDOM_RegimeTributario)
        {
            this.IDOM_RegimeTributario = IDOM_RegimeTributario;
        }


        [HttpGet("/api/ListaRegimeTributario")]
        public async Task<JsonResult> ListaRegimeTributario()
        {
            return Json(await this.IDOM_RegimeTributario.List());
        }



    }
}