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
    public class TributoApiController : Controller
    {
        private readonly ITributo ITributo;

        public TributoApiController(ITributo ITributo)
        {
            this.ITributo = ITributo;
        }

        [HttpGet("/api/ListaTributo")]
        public async Task<JsonResult> ListaTributo()
        {
            try
            {
                return Json(await this.ITributo.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os tributos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTributo")]
        public async Task<JsonResult> AdicionarTributo([FromBody] Tributo Tributo)
        {
            try
            {
                if (string.IsNullOrEmpty(Tributo.Codigo))
                    return Json(BadRequest(ModelState));
                if (string.IsNullOrEmpty(Tributo.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITributo.Add(Tributo)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o tributo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTributoPorId/{id}")]
        public async Task<JsonResult> RetornaTributoPorId(int id)
        {
            try
            {
                return Json(await this.ITributo.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o tributo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTributo")]
        public async Task<JsonResult> EditarTributo([FromBody] Tributo Tributo)
        {
            try
            {
                if (string.IsNullOrEmpty(Tributo.Codigo))
                    return Json(BadRequest(ModelState));
                if (string.IsNullOrEmpty(Tributo.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITributo.Update(Tributo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o tributo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTributo")]
        public async Task<JsonResult> ExcluirTributo([FromBody] Tributo Tributo)
        {
            try
            {
                Json(await Task.FromResult(this.ITributo.Delete(Tributo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o tributo " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
