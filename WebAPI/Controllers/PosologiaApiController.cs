using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class PosologiaApiController: Controller
    {
        private readonly IPosologia IPosologia;

        public PosologiaApiController(IPosologia IPosologia)
        {
            this.IPosologia = IPosologia;
        }

        [HttpGet("/api/ListaPosologia")]
        public async Task<JsonResult> ListaPosologia()
        {
            try
            {
                return Json(await this.IPosologia.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as posologias " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarPosologia")]
        public async Task<JsonResult> AdicionarPosologia([FromBody] Posologia Posologia)
        {
            try
            {
                if (String.IsNullOrEmpty(Posologia.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPosologia.Add(Posologia)));

                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a posologia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaPosologiaPorId/{id}")]
        public async Task<JsonResult> RetornaPosologiaPorId(int id)
        {
            try
            {
                return Json(await this.IPosologia.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a posologia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPosologia")]
        public async Task<JsonResult> EditarPosologia([FromBody] Posologia Posologia)
        {
            try
            {
                if (String.IsNullOrEmpty(Posologia.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPosologia.Update(Posologia)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a posologia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPosologia")]
        public async Task<JsonResult> ExcluirPosologia([FromBody] Posologia Posologia)
        {
            try
            {
                return Json(await Task.FromResult(this.IPosologia.Delete(Posologia)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a posologia " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
