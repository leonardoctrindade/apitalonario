using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class TransportadorApiController : Controller
    {
        private readonly ITransportador ITransportador;

        public TransportadorApiController(ITransportador ITransportador)
        {
            this.ITransportador = ITransportador;
        }

        [HttpGet("/api/ListaTransportador")]
        public async Task<JsonResult> ListaTransportador()
        {
            try
            {

                return Json(await this.ITransportador.List());
            }
            catch (Exception)
            {

                return Json(BadRequest(ModelState));
            }
        }

        [HttpPost("/api/AdicionarTransportador")]
        public async Task<JsonResult> AdicionarTransportador([FromBody] Transportador Transportador)
        {
            if (String.IsNullOrEmpty(Transportador.Nome))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Transportador.CpfCnpj))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITransportador.Add(Transportador)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaTransportadorPorId/{id}")]
        public async Task<JsonResult> RetornaTransportadorPorId(int id)
        {
            try
            {

                return Json(await this.ITransportador.GetEntityById(id));
            }
            catch (Exception)
            {

                return Json(BadRequest(ModelState));
            }
        }

        [HttpPost("/api/EditarTransportador")]
        public async Task<JsonResult> EditarTransportador([FromBody] Transportador Transportador)
        {
            if(String.IsNullOrEmpty(Transportador.Nome))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Transportador.CpfCnpj))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITransportador.Update(Transportador)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirTransportador")]
        public async Task ExcluirTransportador([FromBody] Transportador Transportador)
        {
            await Task.FromResult(this.ITransportador.Delete(Transportador));
        }
    }
}
