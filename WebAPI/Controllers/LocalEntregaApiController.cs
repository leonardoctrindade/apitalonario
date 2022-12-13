using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class LocalEntregaApiController : Controller
    {
        private readonly ILocalEntrega ILocalEntrega;

        public LocalEntregaApiController(ILocalEntrega ILocalEntrega)
        {
            this.ILocalEntrega = ILocalEntrega;
        }

        [HttpGet("/api/ListaLocalEntrega")]
        public async Task<JsonResult> ListaLocalEntrega()
        {
            return Json(await this.ILocalEntrega.List());
        }

        [HttpPost("/api/AdicionarLocalEntrega")]
        public async Task<JsonResult> AdicionarLocalEntrega([FromBody] LocalEntrega LocalEntrega)
        {
            if (String.IsNullOrEmpty(LocalEntrega.Descricao))
                return Json(BadRequest(ModelState));
            if (LocalEntrega.TaxaEntrega <= 0) 
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ILocalEntrega.Add(LocalEntrega)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaLocalEntregaPorId/{id}")]
        public async Task<JsonResult> RetornaLocalEntregaPorId(int id)
        {
            return Json(await this.ILocalEntrega.GetEntityById(id));
        }

        [HttpPost("/api/EditarLocalEntrega")]
        public async Task<JsonResult> EditarLocalEntrega([FromBody] LocalEntrega LocalEntrega)
        {
            if (String.IsNullOrEmpty(LocalEntrega.Descricao))
                return Json(BadRequest(ModelState));
            if (LocalEntrega.TaxaEntrega <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ILocalEntrega.Update(LocalEntrega)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirLocalEntrega")]
        public async Task ExcluirLocalEntrega([FromBody] LocalEntrega LocalEntrega)
        {
            await Task.FromResult(this.ILocalEntrega.Delete(LocalEntrega));
        }
    }
}
