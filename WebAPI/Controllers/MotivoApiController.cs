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
    public class MotivoApiController : Controller
    {
        private readonly IMotivo IMotivo;

        public MotivoApiController(IMotivo imotivo)
        {
            IMotivo = imotivo;
        }

        [HttpGet("/api/ListaMotivo")]
        public async Task<JsonResult> ListaMotivo()
        {
            try
            {
                return Json(await this.IMotivo.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os motivos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarMotivo")]
        public async Task<JsonResult> AdicionarMotivo([FromBody] Motivo motivo)
        {
            try
            {
                if (string.IsNullOrEmpty(motivo.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IMotivo.Add(motivo)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o motivo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarMotivoPorId/{id}")]
        public async Task<JsonResult> RetornarMotivoPorId(int id)
        {
            try
            {
                if (id == 0)
                    return Json(BadRequest(ModelState));

                return Json(await this.IMotivo.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o motivo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarMotivo")]
        public async Task<JsonResult> EditarMotivo([FromBody] Motivo motivo)
        {
            try
            {
                if (string.IsNullOrEmpty(motivo.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IMotivo.Update(motivo)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o motivo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirMotivo")]
        public async Task<JsonResult> ExcluirMotivo([FromBody] Motivo motivo)
        {
            try
            {
                Json(await Task.FromResult(this.IMotivo.Delete(motivo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o motivo " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
