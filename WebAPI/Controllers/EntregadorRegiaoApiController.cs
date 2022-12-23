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
    public class EntregadorRegiaoApiController : Controller
    {
        private readonly IEntregadorRegiao IEntregadorRegiao;

        public EntregadorRegiaoApiController(IEntregadorRegiao IEntregadorRegiao)
        {
            this.IEntregadorRegiao = IEntregadorRegiao;
        }

        [HttpGet("/api/ListaEntregadorRegiao")]
        public async Task<JsonResult> ListaEntregadorRegiao()
        {
            try
            {
                return Json(await this.IEntregadorRegiao.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os entregadores da região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEntregadorRegiao")]
        public async Task<JsonResult> AdicionarEntregadorRegiao([FromBody] EntregadorRegiao EntregadorRegiao)
        {
            try
            {
                if (EntregadorRegiao.IdEntregador == 0 || EntregadorRegiao.IdRegiao == 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEntregadorRegiao.Add(EntregadorRegiao)));

                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o entregador da região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaEntregadorRegiaoPorId/{id}")]
        public async Task<JsonResult> RetornaEntregadorRegiaoPorId(int id)
        {
            try
            {
                return Json(await this.IEntregadorRegiao.GetEntityById(id));
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar o entregador da região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEntregadorRegiao")]
        public async Task<JsonResult> EditarEntregadorRegiao([FromBody] EntregadorRegiao EntregadorRegiao)
        {
            try
            {
                if (EntregadorRegiao.IdEntregador == 0 || EntregadorRegiao.IdRegiao == 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEntregadorRegiao.Update(EntregadorRegiao)));
                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o entregador da região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEntregadorRegiao")]
        public async Task<JsonResult> ExcluirEntregadorRegiao([FromBody] EntregadorRegiao EntregadorRegiao)
        {
            try
            {
                return Json(await Task.FromResult(this.IEntregadorRegiao.Delete(EntregadorRegiao)));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o entregador da região " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
