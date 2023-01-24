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
    public class NaturezaOperacaoApiController : Controller
    {
        private readonly INaturezaOperacao INaturezaOperacao;

        public NaturezaOperacaoApiController(INaturezaOperacao INaturezaOperacao)
        {
            this.INaturezaOperacao = INaturezaOperacao;
        }

        [HttpGet("/api/ListaPaginacaoNaturezaOperacao/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var naturezas = await this.INaturezaOperacao.List();

                var total = Convert.ToDouble(naturezas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.INaturezaOperacao.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : naturezas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os naturezas da operação " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaNaturezaOperacao")]
        public async Task<JsonResult> ListaNaturezaOperacao()
        {
            try
            {
                return Json(await this.INaturezaOperacao.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as naturezas da operação " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarNaturezaOperacao")]
        public async Task<IActionResult> AdicionarNaturezaOperacao([FromBody] NaturezaOperacao NaturezaOperacao)
        {
            try
            {
                if (String.IsNullOrEmpty(NaturezaOperacao.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (NaturezaOperacao.Tipo != 1 && NaturezaOperacao.Tipo != 2)
                    return BadRequest("Campo de tipo é obrigatório");
                if (NaturezaOperacao.Codigo <= 0)
                    return BadRequest("Campo de código é obrigatório");

                Json(await Task.FromResult(this.INaturezaOperacao.Add(NaturezaOperacao)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a natureza da operação " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaNaturezaOperacaoPorId/{id}")]
        public async Task<JsonResult> RetornaNaturezaOperacaoPorId(int id)
        {
            try
            {
                return Json(await this.INaturezaOperacao.GetNaturezaOperacao(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a natureza da operação " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarNaturezaOperacao")]
        public async Task<IActionResult> EditarNaturezaOperacao([FromBody] NaturezaOperacao NaturezaOperacao)
        {
            try
            {
                if (String.IsNullOrEmpty(NaturezaOperacao.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (NaturezaOperacao.Tipo != 1 && NaturezaOperacao.Tipo != 2)
                    return BadRequest("Campo de tipo é obrigatório");
                if (NaturezaOperacao.Codigo <= 0)
                    return BadRequest("Campo de código é obrigatório");

                Json(await Task.FromResult(this.INaturezaOperacao.Update(NaturezaOperacao)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a natureza da operação " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirNaturezaOperacao")]
        public async Task<JsonResult> ExcluirNaturezaOperacao([FromBody] NaturezaOperacao NaturezaOperacao)
        {
            try
            {
                Json(await Task.FromResult(this.INaturezaOperacao.Delete(NaturezaOperacao)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a natureza da operação " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
