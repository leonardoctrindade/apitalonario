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
    public class TransportadorApiController : Controller
    {
        private readonly ITransportador ITransportador;
        
        public TransportadorApiController(ITransportador transportador)
        {
            this.ITransportador = transportador;
        }
        [HttpGet("/api/ListaTransportador")]
        public async Task<JsonResult> ListaTransportador()
        {
            return Json(await this.ITransportador.List());
        }
        [HttpPost("/api/AdicionarTransportador")]
        public async Task<JsonResult> AdicionarTransportador([FromBody] Transportador transportador)
        {
            if (string.IsNullOrEmpty(transportador.Nome) || string.IsNullOrEmpty(transportador.CpfCnpj))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITransportador.Add(transportador)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarTransportadorPorId/{id}")]
        public async Task<JsonResult> RetornarTransportadorPorId(int id)
        {
            if(id <= 0)
                return Json(BadRequest(ModelState));

            return Json(await this.ITransportador.GetEntityById(id));
        }
        [HttpPost("/api/EditarTransportador")]
        public async Task<JsonResult> EditarTransportador([FromBody] Transportador transportador)
        {
            if (string.IsNullOrEmpty(transportador.Nome) || string.IsNullOrEmpty(transportador.CpfCnpj))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITransportador.Update(transportador)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirTransportador")]
        public async Task ExcluirTransportador([FromBody] Transportador transportador)
        {
            await Task.FromResult(this.ITransportador.Delete(transportador));
        }
    }
}
