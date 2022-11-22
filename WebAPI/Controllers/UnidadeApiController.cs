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
    public class UnidadeApiController : Controller
    {
        private readonly IUnidade IUnidade;
        public UnidadeApiController(IUnidade iunidade)
        {
            this.IUnidade = iunidade;
        }
        [HttpGet("/api/ListaUnidade")]
        public async Task<JsonResult> ListaUnidade()
        {
            return Json(await this.IUnidade.List());
        }
        [HttpPost("/api/AdicionarUnidade")]
        public async Task<JsonResult> AdicionarUnidade([FromBody] Unidade unidade)
        {
            if (string.IsNullOrEmpty(unidade.Sigla) || string.IsNullOrEmpty(unidade.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IUnidade.Add(unidade)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarUnidadePorId/{id}")]
        public async Task<JsonResult> RetornarUnidadeProId(int id)
        {
            if(id == 0)
                return Json(BadRequest(ModelState));

            return Json(await this.IUnidade.GetEntityById(id));
        }
        [HttpPost("/api/EditarUnidade")]
        public async Task<JsonResult> EditarUnidade([FromBody] Unidade unidade)
        {
            if (string.IsNullOrEmpty(unidade.Sigla) || string.IsNullOrEmpty(unidade.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IUnidade.Update(unidade)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirUnidade")]
        public async Task ExcluirUnidade([FromBody] Unidade unidade)
        {
            await Task.FromResult(this.IUnidade.Delete(unidade));
        }

    }
}
