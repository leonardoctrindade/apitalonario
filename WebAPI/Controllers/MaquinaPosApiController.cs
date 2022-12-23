using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class MaquinaPosApiController : Controller
    {
        private readonly IMaquinaPos IMaquinaPos;

        public MaquinaPosApiController(IMaquinaPos IMaquinaPos)
        {
            this.IMaquinaPos = IMaquinaPos;
        }

        [HttpGet("/api/ListaMaquinaPos")]
        public async Task<JsonResult> ListaMaquinaPos()
        {
            try
            {
                return Json(await this.IMaquinaPos.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as maquinas pos" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarMaquinaPos")]
        public async Task<JsonResult> AdicionarMaquinaPos([FromBody] MaquinaPos MaquinaPos)
        {
            try
            {
                if (String.IsNullOrEmpty(MaquinaPos.SerialPos))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IMaquinaPos.Add(MaquinaPos)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a maquina pos" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaMaquinaPosPorId/{id}")]
        public async Task<JsonResult> RetornaMaquinaPosPorId(int id)
        {
            try
            {
                return Json(await this.IMaquinaPos.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a maquina pos" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarMaquinaPos")]
        public async Task<JsonResult> EditarMaquinaPos([FromBody] MaquinaPos MaquinaPos)
        {
            try
            {
                if (String.IsNullOrEmpty(MaquinaPos.SerialPos))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IMaquinaPos.Update(MaquinaPos)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a maquina pos" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExlcuirMaquinaPos")]
        public async Task<JsonResult> ExcluirMaquinaPos([FromBody] MaquinaPos MaquinaPos)
        {
            try
            {
                return Json(await Task.FromResult(this.IMaquinaPos.Delete(MaquinaPos)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a maquina pos" + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
