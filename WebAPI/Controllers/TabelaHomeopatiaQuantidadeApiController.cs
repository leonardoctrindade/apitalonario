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
    public class TabelaHomeopatiaQuantidadeApiController: Controller
    {
        private readonly ITabelaHomeopatiaQuantidade ITabelaHomeopatiaQuantidade;

        public TabelaHomeopatiaQuantidadeApiController(ITabelaHomeopatiaQuantidade ITabelaHomeopatiaQuantidade)
        {
            this.ITabelaHomeopatiaQuantidade = ITabelaHomeopatiaQuantidade;
        }

        [HttpGet("/api/ListaTabelaHomeopatiaQuantidade")]
        public async Task<JsonResult> ListaTabelaHomeopatiaQuantidade()
        {
            return Json(await this.ITabelaHomeopatiaQuantidade.List());
        }

        [HttpPost("/api/AdicionarTabelaHomeopatiaQuantidade")]
        public async Task<JsonResult> AdicionarTabelaHomeopatiaQuantidade([FromBody] TabelaHomeopatiaQuantidade TabelaHomeopatiaQuantidade)
        {
            if (String.IsNullOrEmpty(TabelaHomeopatiaQuantidade.Metodo))
                return Json(BadRequest(ModelState));
            if (TabelaHomeopatiaQuantidade.DinamizacaoInicial <= 0 || TabelaHomeopatiaQuantidade.DinamizacaoFinal <= 0)
                return Json(BadRequest(ModelState));
            if (TabelaHomeopatiaQuantidade.QuantidadeInicial < 0 || TabelaHomeopatiaQuantidade.QuantidadeFinal <= 0)
                return Json(BadRequest(ModelState));
            if (TabelaHomeopatiaQuantidade.ValorVenda < 0 || TabelaHomeopatiaQuantidade.ValorAdicional < 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITabelaHomeopatiaQuantidade.Add(TabelaHomeopatiaQuantidade)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaTabelaHomeopatiaQuantidadePorId/{id}")]
        public async Task<JsonResult> RetornaTabelaHomeopatiaQuantidadePorId(int id)
        {
            return Json(await this.ITabelaHomeopatiaQuantidade.GetEntityById(id));
        }

        [HttpPost("/api/EditarTabelaHomeopatiaQuantidade")]
        public async Task<JsonResult> EditarTabelaHomeopatiaQuantidade([FromBody] TabelaHomeopatiaQuantidade TabelaHomeopatiaQuantidade)
        {
            if (String.IsNullOrEmpty(TabelaHomeopatiaQuantidade.Metodo))
                return Json(BadRequest(ModelState));
            if (TabelaHomeopatiaQuantidade.DinamizacaoInicial <= 0 || TabelaHomeopatiaQuantidade.DinamizacaoFinal <= 0)
                return Json(BadRequest(ModelState));
            if (TabelaHomeopatiaQuantidade.QuantidadeInicial < 0 || TabelaHomeopatiaQuantidade.QuantidadeFinal <= 0)
                return Json(BadRequest(ModelState));
            if (TabelaHomeopatiaQuantidade.ValorVenda < 0 || TabelaHomeopatiaQuantidade.ValorAdicional < 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITabelaHomeopatiaQuantidade.Update(TabelaHomeopatiaQuantidade)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirTabelaHomeopatiaQuantidade")]
        public async Task ExcluirTabelaHomeopatiaQuantidade([FromBody] TabelaHomeopatiaQuantidade TabelaHomeopatiaQuantidade)
        {
            await Task.FromResult(this.ITabelaHomeopatiaQuantidade.Delete(TabelaHomeopatiaQuantidade));
        }
    }
}
