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
    public class EntregadorApiController: Controller
    {
        private readonly IEntregador IEntregador;

        public EntregadorApiController(IEntregador IEntregador)
        {
            this.IEntregador = IEntregador;
        }

        [HttpGet("/api/ListaEntregador")]
        public async Task<JsonResult> ListaEntregador()
        {
            return Json(await this.IEntregador.List());
        }

        [HttpPost("/api/AdicionarEntregador")]
        public async Task<JsonResult> AdicionarEntregador([FromBody] Entregador Entregador)
        {
            if (String.IsNullOrEmpty(Entregador.Nome))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Entregador.Ddd))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Entregador.Telefone))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEntregador.Add(Entregador)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaEntregadorPorId/{id}")]
        public async Task<JsonResult> RetornaEntregadorPorId(int id)
        {
            return Json(await this.IEntregador.GetEntityById(id));
        }

        [HttpPost("/api/EditarEntregador")]
        public async Task<JsonResult> EditarEntregador([FromBody] Entregador Entregador)
        {
            if (String.IsNullOrEmpty(Entregador.Nome))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Entregador.Ddd))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Entregador.Telefone))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEntregador.Update(Entregador)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirEntregador")]
        public async Task ExcluirEntregador([FromBody] Entregador Entregador)
        {
            await Task.FromResult(this.IEntregador.Delete(Entregador));
        }
    }
}
