using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class PosAdquirenteApiController : Controller
    {
        private readonly IPosAdquirente IPosAdquirente;

        public PosAdquirenteApiController(IPosAdquirente IPosAdquirente)
        {
            this.IPosAdquirente = IPosAdquirente;
        }

        [HttpGet("/api/ListaPosAdquirente")]
        public async Task<JsonResult> ListaPosAdquirente()
        {
            try
            {
                return Json(await this.IPosAdquirente.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os pos adquirentes " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarPosAdquirente")]
        public async Task<JsonResult> AdicionarPosAdquirente([FromBody] PosAdquirente PosAdquirente)
        {
            try
            {
                if (String.IsNullOrEmpty(PosAdquirente.ChaveRequisicao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPosAdquirente.Add(PosAdquirente)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o pos adquirente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaPosAdquirentePorId/{id}")]
        public async Task<JsonResult> RetornaPosAdquirentePorId(int id)
        {
            try
            {
                return Json(await this.IPosAdquirente.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o pos adquirente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPosAdquirente")]
        public async Task<JsonResult> EditarPosAdquirente([FromBody] PosAdquirente PosAdquirente)
        {
            try
            {
                if (String.IsNullOrEmpty(PosAdquirente.ChaveRequisicao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPosAdquirente.Update(PosAdquirente)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o pos adquirente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPosAdquirente")]
        public async Task<JsonResult> ExcluirPosAdquirente([FromBody] PosAdquirente PosAdquirente)
        {
            try
            {
                return Json(await Task.FromResult(this.IPosAdquirente.Delete(PosAdquirente)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o pos adquirente " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
