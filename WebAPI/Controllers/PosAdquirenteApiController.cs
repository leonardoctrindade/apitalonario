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
            return Json(await this.IPosAdquirente.List());
        }

        [HttpPost("/api/AdicionarPosAdquirente")]
        public async Task<JsonResult> AdicionarPosAdquirente([FromBody] PosAdquirente PosAdquirente)
        {
            if (String.IsNullOrEmpty(PosAdquirente.ChaveRequisicao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPosAdquirente.Add(PosAdquirente)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaPosAdquirentePorId/{id}")]
        public async Task<JsonResult> RetornaPosAdquirentePorId(int id)
        {
            return Json(await this.IPosAdquirente.GetEntityById(id));
        }

        [HttpPost("/api/EditarPosAdquirente")]
        public async Task<JsonResult> EditarPosAdquirente([FromBody] PosAdquirente PosAdquirente)
        {
            if (String.IsNullOrEmpty(PosAdquirente.ChaveRequisicao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPosAdquirente.Update(PosAdquirente)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirPosAdquirente")]
        public async Task ExcluirPosAdquirente([FromBody] PosAdquirente PosAdquirente)
        {
            await Task.FromResult(this.IPosAdquirente.Delete(PosAdquirente));
        }
    }
}
