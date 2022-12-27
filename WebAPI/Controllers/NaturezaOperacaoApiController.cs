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
        public async Task<JsonResult> AdicionarNaturezaOperacao([FromBody] NaturezaOperacao NaturezaOperacao)
        {
            try
            {
                if (String.IsNullOrEmpty(NaturezaOperacao.Descricao))
                    return Json(BadRequest(ModelState));
                if (NaturezaOperacao.Tipo != 1 && NaturezaOperacao.Tipo != 2)
                    return Json(BadRequest(ModelState));
                if (NaturezaOperacao.Codigo <= 0)
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarNaturezaOperacao([FromBody] NaturezaOperacao NaturezaOperacao)
        {
            try
            {
                if (String.IsNullOrEmpty(NaturezaOperacao.Descricao))
                    return Json(BadRequest(ModelState));
                if (NaturezaOperacao.Tipo != 1 && NaturezaOperacao.Tipo != 2)
                    return Json(BadRequest(ModelState));
                if (NaturezaOperacao.Codigo <= 0)
                    return Json(BadRequest(ModelState));

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
                return Json(await Task.FromResult(this.INaturezaOperacao.Delete(NaturezaOperacao)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a natureza da operação " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
