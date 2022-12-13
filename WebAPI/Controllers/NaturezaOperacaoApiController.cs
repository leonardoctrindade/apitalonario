using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            return Json(await this.INaturezaOperacao.List());
        }

        [HttpPost("/api/AdicionarNaturezaOperacao")]
        public async Task<JsonResult> AdicionarNaturezaOperacao([FromBody] NaturezaOperacao NaturezaOperacao)
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

        [HttpGet("/api/RetornaNaturezaOperacaoPorId/{id}")]
        public async Task<JsonResult> RetornaNaturezaOperacaoPorId(int id)
        {
            return Json(await this.INaturezaOperacao.GetEntityById(id));
        }

        [HttpPost("/api/EditarNaturezaOperacao")]
        public async Task<JsonResult> EditarNaturezaOperacao([FromBody] NaturezaOperacao NaturezaOperacao)
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

        [HttpPost("/api/ExcluirNaturezaOperacao")]
        public async Task ExcluirNaturezaOperacao([FromBody] NaturezaOperacao NaturezaOperacao)
        {
            await Task.FromResult(this.INaturezaOperacao.Delete(NaturezaOperacao));
        }
    }
}
