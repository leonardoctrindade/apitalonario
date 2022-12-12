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
            return Json(await this.IPosologia.List());
        }

        [HttpPost("/api/AdicionarPosologia")]
        public async Task<JsonResult> AdicionarPosologia([FromBody] Posologia Posologia)
        {
            if (String.IsNullOrEmpty(Posologia.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPosologia.Add(Posologia)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaPosologiaPorId/{id}")]
        public async Task<JsonResult> RetornaPosologiaPorId(int id)
        {
            return Json(await this.IPosologia.GetEntityById(id));
        }

        [HttpPost("/api/EditarPosologia")]
        public async Task<JsonResult> EditarPosologia([FromBody] Posologia Posologia)
        {
            if (String.IsNullOrEmpty(Posologia.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPosologia.Update(Posologia)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirPosologia")]
        public async Task ExcluirPosologia([FromBody] Posologia Posologia)
        {
            await Task.FromResult(this.IPosologia.Delete(Posologia));
        }
    }
}
