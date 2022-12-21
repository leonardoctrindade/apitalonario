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
    public class FidelidadeFormaPagamentoApiController : Controller
    {
        private readonly IFidelidadeFormaPagamento IFidelidadeFormaPagamento;

        public FidelidadeFormaPagamentoApiController(IFidelidadeFormaPagamento IFidelidadeFormaPagamento)
        {
            this.IFidelidadeFormaPagamento = IFidelidadeFormaPagamento;
        }

        [HttpGet("/api/ListaFidelidadeFormaPagamento")]
        public async Task<JsonResult> ListaFidelidadeFormaPagamento()
        {
            return Json(await this.IFidelidadeFormaPagamento.List());
        }

        [HttpPost("/api/AdicionarFidelidadeFormaPagamento")]
        public async Task<JsonResult> AdicionarFidelidadeFormaPagamento([FromBody] FidelidadeFormaPagamento FidelidadeFormaPagamento)
        {
            if (FidelidadeFormaPagamento.Valor < 0 || FidelidadeFormaPagamento.Pontos < 0 || FidelidadeFormaPagamento.CodigoFormaPagamento == 0 || FidelidadeFormaPagamento.CodigoFidelidade == 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFidelidadeFormaPagamento.Add(FidelidadeFormaPagamento)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaFidelidadeFormaPagamentoPorId/{id}")]
        public async Task<JsonResult> RetornaFidelidadeFormaPagamentoPorId(int id)
        {
            return Json(await this.IFidelidadeFormaPagamento.GetEntityById(id));
        }

        [HttpPost("/api/EditarFidelidadeFormaPagamento")]
        public async Task<JsonResult> EditarFidelidadeFormaPagamento([FromBody] FidelidadeFormaPagamento FidelidadeFormaPagamento)
        {
            if (FidelidadeFormaPagamento.Valor < 0 || FidelidadeFormaPagamento.Pontos < 0 || FidelidadeFormaPagamento.CodigoFormaPagamento == 0 || FidelidadeFormaPagamento.CodigoFidelidade == 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFidelidadeFormaPagamento.Update(FidelidadeFormaPagamento)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirFidelidadeFormaPagamento")]
        public async Task ExcluirFidelidadeFormaPagamento([FromBody] FidelidadeFormaPagamento FidelidadeFormaPagamento)
        {
            await Task.FromResult(this.IFidelidadeFormaPagamento.Delete(FidelidadeFormaPagamento));
        }
    }
}
