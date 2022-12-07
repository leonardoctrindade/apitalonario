using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class FormaPagamentoApiController: Controller
    {
        private readonly IFormaPagamento IFormaPagamento;

        public FormaPagamentoApiController(IFormaPagamento IFormaPagamento)
        {
            this.IFormaPagamento = IFormaPagamento;
        }

        [HttpGet("/api/ListaFormaPagamento")]
        public async Task<JsonResult> ListaFormaPagamento()
        {
            return Json(await this.IFormaPagamento.List());
        }

        [HttpPost("/api/AdicionarFormaPagamento")]
        public async Task<JsonResult> AdicionarFormaPagamento([FromBody] FormaPagamento FormaPagamento)
        {
            if (String.IsNullOrEmpty(FormaPagamento.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFormaPagamento.Add(FormaPagamento)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaFormaPagamentoPorId/{id}")]
        public async Task<JsonResult> RetornaFormaPagamentoPorId(int id)
        {
            return Json(await this.IFormaPagamento.GetEntityById(id));
        }

        [HttpPost("/api/EditarFormaPagamento")]
        public async Task<JsonResult> EditarFormaPagamento([FromBody] FormaPagamento FormaPagamento)
        {
            if (String.IsNullOrEmpty(FormaPagamento.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFormaPagamento.Update(FormaPagamento)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirFormaPagamento")]
        public async Task ExcluirFormaPagamento([FromBody] FormaPagamento FormaPagamento)
        {
            await Task.FromResult(this.IFormaPagamento.Delete(FormaPagamento));
        }
    }
}
