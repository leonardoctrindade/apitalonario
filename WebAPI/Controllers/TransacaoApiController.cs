using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class TransacaoApiController : Controller
    {
        private readonly ITransacao ITransacao;

        public TransacaoApiController(ITransacao ITransacao)
        {
            this.ITransacao = ITransacao;
        }

        [HttpGet("/api/ListaTransacao")]
        public async Task<JsonResult> ListaTransacao()
        {
            return Json(await this.ITransacao.List());
        }

        [HttpPost("/api/AdicionarTransacao")]
        public async Task<JsonResult> AdicionarTransacao([FromBody] Transacao Transacao)
        {
            if (String.IsNullOrEmpty(Transacao.Descricao))
                return Json(BadRequest(ModelState));
            if (Transacao.Tipo != 1 && Transacao.Tipo != 2)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITransacao.Add(Transacao)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaTransacaoPorId/{id}")]
        public async Task<JsonResult> RetornaTransacaoPorId(int id)
        {
            return Json(await this.ITransacao.GetEntityById(id));
        }

        [HttpPost("/api/EditarTransacao")]
        public async Task<JsonResult> EditarTransacao([FromBody] Transacao Transacao)
        {
            if (String.IsNullOrEmpty(Transacao.Descricao))
                return Json(BadRequest(ModelState));
            if (Transacao.Tipo != 1 && Transacao.Tipo != 2)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITransacao.Update(Transacao)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirTransacao")]
        public async Task ExcluirTransacao([FromBody] Transacao Transacao)
        {
            await Task.FromResult(this.ITransacao.Delete(Transacao));
        }
    }
}
