using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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
            try
            {
                return Json(await this.IDOM_RegimeTributario.List());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os regimes tributarios " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaRegimeTributarioPorID/{id}")]
        public async Task<JsonResult> RetornaRegimeTributarioPorID(int id)
        {
            try
            {
                return Json(await this.IDOM_RegimeTributario.RetornaRegimeTributarioPorID(id));
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retorna o regime tributario " + ex.Message }) { StatusCode = 400 };
            }
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
            try
            {
                if (String.IsNullOrEmpty(dOM_RegimeTributario.RegimeTributario))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IDOM_RegimeTributario.Add(dOM_RegimeTributario)));

                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o regime tributario " + ex.Message }) { StatusCode = 400 };
            }
        }

    }
}