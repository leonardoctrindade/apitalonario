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
            try
            {
                return Json(await this.IFidelidadeFormaPagamento.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as fidelidade de forma de pagamento" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFidelidadeFormaPagamento")]
        public async Task<JsonResult> AdicionarFidelidadeFormaPagamento([FromBody] FidelidadeFormaPagamento FidelidadeFormaPagamento)
        {
            try
            {
                if (FidelidadeFormaPagamento.Valor < 0 || FidelidadeFormaPagamento.Pontos < 0 || FidelidadeFormaPagamento.CodigoFormaPagamento == 0 || FidelidadeFormaPagamento.CodigoFidelidade == 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFidelidadeFormaPagamento.Add(FidelidadeFormaPagamento)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a fidelidade de forma de pagamento" + ex.Message }) { StatusCode = 400 };
            } 
        }

        [HttpGet("/api/RetornaFidelidadeFormaPagamentoPorId/{id}")]
        public async Task<JsonResult> RetornaFidelidadeFormaPagamentoPorId(int id)
        {
            try
            {
                return Json(await this.IFidelidadeFormaPagamento.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a fidelidade de forma de pagamento" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFidelidadeFormaPagamento")]
        public async Task<JsonResult> EditarFidelidadeFormaPagamento([FromBody] FidelidadeFormaPagamento FidelidadeFormaPagamento)
        {
            try
            {
                if (FidelidadeFormaPagamento.Valor < 0 || FidelidadeFormaPagamento.Pontos < 0 || FidelidadeFormaPagamento.CodigoFormaPagamento == 0 || FidelidadeFormaPagamento.CodigoFidelidade == 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFidelidadeFormaPagamento.Update(FidelidadeFormaPagamento)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar a fidelidade de forma de pagamento" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFidelidadeFormaPagamento")]
        public async Task<JsonResult> ExcluirFidelidadeFormaPagamento([FromBody] FidelidadeFormaPagamento FidelidadeFormaPagamento)
        {
            try
            {
                Json(await Task.FromResult(this.IFidelidadeFormaPagamento.Delete(FidelidadeFormaPagamento)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a fidelidade de forma de pagamento" + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
