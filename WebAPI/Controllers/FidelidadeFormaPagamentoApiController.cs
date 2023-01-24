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

        [HttpGet("/api/ListaPaginacaoFidelidadeFormaPagamento/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var fidelidadesFormaPagamento = await this.IFidelidadeFormaPagamento.List();

                var total = Convert.ToDouble(fidelidadesFormaPagamento.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IFidelidadeFormaPagamento.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : fidelidadesFormaPagamento);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as fidelidades forma pagamento" + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarFidelidadeFormaPagamento([FromBody] FidelidadeFormaPagamento FidelidadeFormaPagamento)
        {
            try
            {
                if (FidelidadeFormaPagamento.Valor < 0)
                    return BadRequest("Campo de valor é obrigatório");
                if (FidelidadeFormaPagamento.Pontos < 0)
                    return BadRequest("Campo de pontos é obrigatório");
                if (FidelidadeFormaPagamento.CodigoFormaPagamento == 0)
                    return BadRequest("Campo de codigo forma pagamento é obrigatório");
                if (FidelidadeFormaPagamento.CodigoFidelidade == 0)
                    return BadRequest("Campo de codigo fidelidade é obrigatório");

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
        public async Task<IActionResult> EditarFidelidadeFormaPagamento([FromBody] FidelidadeFormaPagamento FidelidadeFormaPagamento)
        {
            try
            {
                if (FidelidadeFormaPagamento.Valor < 0)
                    return BadRequest("Campo de valor é obrigatório");
                if (FidelidadeFormaPagamento.Pontos < 0)
                    return BadRequest("Campo de pontos é obrigatório");
                if (FidelidadeFormaPagamento.CodigoFormaPagamento == 0)
                    return BadRequest("Campo de codigo forma pagamento é obrigatório");
                if (FidelidadeFormaPagamento.CodigoFidelidade == 0)
                    return BadRequest("Campo de codigo fidelidade é obrigatório");

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
