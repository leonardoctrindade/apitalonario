using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class TransacaoApiController : Controller
    {
        private readonly ITransacao ITransacao;

        public TransacaoApiController(ITransacao ITransacao)
        {
            this.ITransacao = ITransacao;
        }

        [HttpGet("/api/ListaPaginacaoTransacao/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var transacoes = await this.ITransacao.List();

                var total = Convert.ToDouble(transacoes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ITransacao.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : transacoes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os transações " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarTransacao([FromBody] Transacao Transacao)
        {
            try
            {
                if (string.IsNullOrEmpty(Transacao.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (Transacao.Tipo != 1 && Transacao.Tipo != 2)
                    return BadRequest("Campo de Tipo é obrigatório");

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
        public async Task<IActionResult> EditarTransacao([FromBody] Transacao Transacao)
        {
            try
            {
                if (string.IsNullOrEmpty(Transacao.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (Transacao.Tipo != 1 && Transacao.Tipo != 2)
                    return BadRequest("Campo de Tipo é obrigatório");

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
                Json(await Task.FromResult(this.ITransacao.Delete(Transacao)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a transação " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
