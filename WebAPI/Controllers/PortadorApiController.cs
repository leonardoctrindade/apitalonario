using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers

{
    public class PortadorApiController : Controller
    {
        private readonly IPortador IPortador;

        public PortadorApiController(IPortador IPortador)
        {
            this.IPortador = IPortador;
        }

        [HttpGet("/api/ListaPortador")]
        public async Task<JsonResult> ListaPortador()
        {
            return Json(await this.IPortador.List());
        }

        [HttpPost("/api/AdicionarPortador")]
        public async Task<JsonResult> AdicionarPortador([FromBody] Portador Portador)
        {
            if (String.IsNullOrEmpty(Portador.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPortador.Add(Portador)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaPortadorPorId/{id}")]
        public async Task<JsonResult> RetornaPortadorPorId(int id)
        {
            return Json(await this.IPortador.GetEntityById(id));
        }

        [HttpPost("/api/EditarPortador")]
        public async Task<JsonResult> EditarPortador([FromBody] Portador Portador)
        {
            if (String.IsNullOrEmpty(Portador.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPortador.Update(Portador)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirPortador")]
        public async Task ExcluirPortador([FromBody] Portador Portador)
        {
            await Task.FromResult(this.IPortador.Delete(Portador));
        }
    }
}
