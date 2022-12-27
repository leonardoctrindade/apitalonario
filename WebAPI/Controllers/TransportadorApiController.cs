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
            try
            {
                return Json(await this.ITransportador.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os transportadores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTransportador")]
        public async Task<JsonResult> AdicionarTransportador([FromBody] Transportador transportador)
        {
            try
            {
                if (string.IsNullOrEmpty(transportador.Nome) || string.IsNullOrEmpty(transportador.CpfCnpj))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITransportador.Add(transportador)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o transportador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarTransportadorPorId/{id}")]
        public async Task<JsonResult> RetornarTransportadorPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return Json(BadRequest(ModelState));

                return Json(await this.ITransportador.GetTransportador(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o transportador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTransportador")]
        public async Task<JsonResult> EditarTransportador([FromBody] Transportador transportador)
        {
            try
            {
                if (string.IsNullOrEmpty(transportador.Nome) || string.IsNullOrEmpty(transportador.CpfCnpj))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITransportador.Update(transportador)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o transportador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTransportador")]
        public async Task<JsonResult> ExcluirTransportador([FromBody] Transportador transportador)
        {
            try
            {
                return Json(await Task.FromResult(this.ITransportador.Delete(transportador)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o transportador " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
