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

        [HttpGet("/api/RetornaRegimeTributarioPorID/{id}")]
        public async Task<JsonResult> RetornaRegimeTributarioPorID(int id)
        {
            return Json(await this.IDOM_RegimeTributario.RetornaRegimeTributarioPorID(id));
        }


        //[HttpPost("/api/AdicionarRegimeTributario")]
        //public async Task<JsonResult> AdicionarRegimeTributario([FromBody] DOM_RegimeTributario dOM_RegimeTributario)
        //{
        //    Json(await Task.FromResult(this.IDOM_RegimeTributario.Add(dOM_RegimeTributario)));
        //    return Json(Ok());
        //}


        [HttpPost("/api/AdicionarRegimeTributario")]
        public async Task<JsonResult> AdicionarRegimeTributario([FromBody] DOM_RegimeTributario dOM_RegimeTributario)
        {
            if (String.IsNullOrEmpty(dOM_RegimeTributario.RegimeTributario))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IDOM_RegimeTributario.Add(dOM_RegimeTributario)));

            return Json(Ok());
        }

    }
}