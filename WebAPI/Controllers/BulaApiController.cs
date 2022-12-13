using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class BulaApiController : Controller
    {
        private readonly IBula IBula;

        public BulaApiController(IBula IBula)
        {
            this.IBula = IBula;
        }

        [HttpGet("/api/ListaBula")]
        public async Task<JsonResult> ListaBula()
        {
            return Json(await this.IBula.List());
        }

        [HttpPost("/api/AdicionarBula")]
        public async Task<JsonResult> AdicionarBula([FromBody] Bula Bula)
        {
            if (String.IsNullOrEmpty(Bula.Descricao))
                return Json(BadRequest(ModelState));
            if (Bula.Tipo != 1 && Bula.Tipo != 2)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IBula.Add(Bula)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaBulaPorId/{id}")]
        public async Task<JsonResult> RetornaBulaPorId(int id)
        {
            return Json(await this.IBula.GetEntityById(id));
        }

        [HttpPost("/api/EditarBula")]
        public async Task<JsonResult> EditarBula([FromBody] Bula Bula)
        {
            if (String.IsNullOrEmpty(Bula.Descricao))
                return Json(BadRequest(ModelState));
            if (Bula.Tipo != 1 && Bula.Tipo != 2)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IBula.Update(Bula)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirBula")]
        public async Task ExcluirBula([FromBody] Bula Bula)
        {
            await Task.FromResult(this.IBula.Delete(Bula));
        }
    }
}
