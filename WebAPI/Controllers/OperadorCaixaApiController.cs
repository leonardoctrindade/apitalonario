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
    public class OperadorCaixaApiController : Controller
    {
        private readonly IOperadorCaixa IOperadorCaixa;

        public OperadorCaixaApiController(IOperadorCaixa IOperadorCaixa)
        {
            this.IOperadorCaixa = IOperadorCaixa;
        }

        [HttpGet("/api/ListaOperadorCaixa")]
        public async Task<JsonResult> ListaOperadorCaixa()
        {
            return Json(await this.IOperadorCaixa.List());
        }

        [HttpPost("/api/AdicionarOperadorCaixa")]
        public async Task<JsonResult> AdicionarOperadorCaixa([FromBody] OperadorCaixa OperadorCaixa)
        {
            if (String.IsNullOrEmpty(OperadorCaixa.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IOperadorCaixa.Add(OperadorCaixa)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaOperadorCaixaPorId/{id}")]
        public async Task<JsonResult> RetornaOperadorCaixaPorId(int id)
        {
            return Json(await this.IOperadorCaixa.GetEntityById(id));
        }

        [HttpPost("/api/EditarOperadorCaixa")]
        public async Task<JsonResult> EditarOperadorCaixa([FromBody] OperadorCaixa OperadorCaixa)
        {
            if (String.IsNullOrEmpty(OperadorCaixa.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IOperadorCaixa.Update(OperadorCaixa)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirOperadorCaixa")]
        public async Task ExcluirOperadorCaixa([FromBody] OperadorCaixa OperadorCaixa)
        {
            await Task.FromResult(this.IOperadorCaixa.Delete(OperadorCaixa));
        }
    }
}
