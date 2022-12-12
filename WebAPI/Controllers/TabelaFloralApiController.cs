using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class TabelaFloralApiController : Controller
    {
        private readonly ITabelaFloral ITabelaFloral;

        public TabelaFloralApiController(ITabelaFloral ITabelaFloral)
        {
            this.ITabelaFloral = ITabelaFloral;
        }

        [HttpGet("/api/ListaTabelaFloral")]
        public async Task<JsonResult> ListaTabelaFloral()
        {
            return Json(await this.ITabelaFloral.List());
        }

        [HttpPost("/api/AdicionarTabelaFloral")]
        public async Task<JsonResult> AdicionarTabelaFloral([FromBody] TabelaFloral TabelaFloral)
        {
            if (TabelaFloral.Volume <= 0 || TabelaFloral.QuantidadeInicial <= 0 || TabelaFloral.QuantidadeFinal <= 0 || TabelaFloral.ValorVenda <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITabelaFloral.Add(TabelaFloral)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaTabelaFloralPorId/{id}")]
        public async Task<JsonResult> RetornaTabelaFloralPorId(int id)
        {
            return Json(await this.ITabelaFloral.GetEntityById(id));
        }

        [HttpPost("/api/EditarTabelaFloral")]
        public async Task<JsonResult> EditarTabelaFloral([FromBody] TabelaFloral TabelaFloral)
        {
            if (TabelaFloral.Volume <= 0 || TabelaFloral.QuantidadeInicial <= 0 || TabelaFloral.QuantidadeFinal <= 0 || TabelaFloral.ValorVenda <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITabelaFloral.Update(TabelaFloral)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirTabelaFloral")]
        public async Task ExcluirTabelaFloral([FromBody] TabelaFloral TabelaFloral)
        {
            await Task.FromResult(this.ITabelaFloral.Delete(TabelaFloral));
        }
    }
}
