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
            try
            {
                return Json(await this.ITransacao.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as transações " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTransacao")]
        public async Task<JsonResult> AdicionarTransacao([FromBody] Transacao Transacao)
        {
            try
            {
                if (String.IsNullOrEmpty(Transacao.Descricao))
                    return Json(BadRequest(ModelState));
                if (Transacao.Tipo != 1 && Transacao.Tipo != 2)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITransacao.Add(Transacao)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a transação " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTransacaoPorId/{id}")]
        public async Task<JsonResult> RetornaTransacaoPorId(int id)
        {
            try
            {
                return Json(await this.ITransacao.GetTransacao(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a transação " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTransacao")]
        public async Task<JsonResult> EditarTransacao([FromBody] Transacao Transacao)
        {
            try
            {
                if (String.IsNullOrEmpty(Transacao.Descricao))
                    return Json(BadRequest(ModelState));
                if (Transacao.Tipo != 1 && Transacao.Tipo != 2)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITransacao.Update(Transacao)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a transação " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTransacao")]
        public async Task<JsonResult> ExcluirTransacao([FromBody] Transacao Transacao)
        {
            try
            {
                return Json(await Task.FromResult(this.ITransacao.Delete(Transacao)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a transação " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
