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
    public class TabelaHomeopatiaApiController: Controller
    {
        private readonly ITabelaHomeopatia ITabelaHomeopatia;

        public TabelaHomeopatiaApiController(ITabelaHomeopatia ITabelaHomeopatia)
        {
            this.ITabelaHomeopatia = ITabelaHomeopatia;
        }

        [HttpGet("/api/ListaTabelaHomeopatia")]
        public async Task<JsonResult> ListaTabelaHomeopatia()
        {
            return Json(await this.ITabelaHomeopatia.List());
        }

        [HttpPost("/api/AdicionarTabelaHomeopatia")]
        public async Task<JsonResult> AdicionarTabelaHomeopatia([FromBody] TabelaHomeopatia TabelaHomeopatia)
        {
            if (String.IsNullOrEmpty(TabelaHomeopatia.Metodo))
                return Json(BadRequest(ModelState));
            if (TabelaHomeopatia.DinamizacaoInicial <= 0 || TabelaHomeopatia.DinamizacaoFinal <= 0 || TabelaHomeopatia.Volume < 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITabelaHomeopatia.Add(TabelaHomeopatia)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaTabelaHomeopatiaPorId/{id}")]
        public async Task<JsonResult> RetornaTabelaHomeopatiaPorId(int id)
        {
            return Json(await this.ITabelaHomeopatia.GetEntityById(id));
        }

        [HttpPost("/api/EditarTabelaHomeopatia")]
        public async Task<JsonResult> EditarTabelaHomeopatia([FromBody] TabelaHomeopatia TabelaHomeopatia)
        {
            if (String.IsNullOrEmpty(TabelaHomeopatia.Metodo))
                return Json(BadRequest(ModelState));
            if (TabelaHomeopatia.DinamizacaoInicial <= 0 || TabelaHomeopatia.DinamizacaoFinal <= 0 || TabelaHomeopatia.Volume < 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITabelaHomeopatia.Update(TabelaHomeopatia)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirTabelaHomeopatia")]
        public async Task ExcluirTabelaHomeopatia([FromBody] TabelaHomeopatia TabelaHomeopatia)
        {
            await Task.FromResult(this.ITabelaHomeopatia.Delete(TabelaHomeopatia));
        }
    }
}
