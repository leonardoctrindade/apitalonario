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
            try
            {
                return Json(await this.IFormaPagamento.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as formas de pagamento " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFormaPagamento")]
        public async Task<JsonResult> AdicionarFormaPagamento([FromBody] FormaPagamento FormaPagamento)
        {
            try
            {
                if (String.IsNullOrEmpty(FormaPagamento.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFormaPagamento.Add(FormaPagamento)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a forma de pagamento " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFormaPagamentoPorId/{id}")]
        public async Task<JsonResult> RetornaFormaPagamentoPorId(int id)
        {
            try
            {
                return Json(await this.IFormaPagamento.GetFormaPagamento(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retorna a forma de pagamento " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFormaPagamento")]
        public async Task<JsonResult> EditarFormaPagamento([FromBody] FormaPagamento FormaPagamento)
        {
            try
            {
                if (String.IsNullOrEmpty(FormaPagamento.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFormaPagamento.Update(FormaPagamento)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a forma de pagamento " + ex.Message }) { StatusCode = 400 };
            }   
        }

        [HttpPost("/api/ExcluirFormaPagamento")]
        public async Task<JsonResult> ExcluirFormaPagamento([FromBody] FormaPagamento FormaPagamento)
        {
            try
            {
                Json(await Task.FromResult(this.IFormaPagamento.Delete(FormaPagamento)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a forma de pagamento " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
