using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    public class FarmacopeiaApiController : Controller
    {
        private readonly IFarmacopeia IFarmacopeia;

        public FarmacopeiaApiController(IFarmacopeia IFarmacopeia)
        {
            this.IFarmacopeia = IFarmacopeia;
        }

        [HttpGet("/api/ListaFarmacopeia")]
        public async Task<JsonResult> ListaFarmacopeia()
        {
            try
            {
                return Json(await this.IFarmacopeia.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as farmacopeias " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFarmacopeia")]
        public async Task<JsonResult> AdicionarFarmacopeia([FromBody] Farmacopeia Farmacopeia)
        {
            try
            {
                if (String.IsNullOrEmpty(Farmacopeia.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFarmacopeia.Add(Farmacopeia)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a farmacopeia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFarmacopeiaPorId/{id}")]
        public async Task<JsonResult> RetornaFarmacopeiaPorId(int id)
        {
            try
            {
                return Json(await this.IFarmacopeia.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a farmacopeia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFarmacopeia")]
        public async Task<JsonResult> EditarFarmacopeia([FromBody] Farmacopeia Farmacopeia)
        {
            try
            {
                if (String.IsNullOrEmpty(Farmacopeia.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFarmacopeia.Update(Farmacopeia)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a farmacopeia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFarmacopeia")]
        public async Task<JsonResult> ExcluirFarmacopeia([FromBody] Farmacopeia Farmacopeia)
        {
            try
            {
                Json(await Task.FromResult(this.IFarmacopeia.Delete(Farmacopeia)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a farmacopeia " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
