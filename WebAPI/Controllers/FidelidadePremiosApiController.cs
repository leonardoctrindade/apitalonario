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
    public class FidelidadePremiosApiController: Controller
    {
        private readonly IFidelidadePremios IFidelidadePremios;

        public FidelidadePremiosApiController(IFidelidadePremios IFidelidadePremios)
        {
            this.IFidelidadePremios = IFidelidadePremios;
        }

        [HttpGet("/api/ListaFidelidadePremios")]
        public async Task<JsonResult> ListaFidelidadePremios()
        {
            return Json(await this.IFidelidadePremios.List());
        }

        [HttpPost("/api/AdicionarFidelidadePremios")]
        public async Task<JsonResult> AdicionarFidelidadePremios([FromBody] FidelidadePremios FidelidadePremios)
        {
            if (FidelidadePremios.IdFidelidade == 0 || FidelidadePremios.IdGrupo == 0 || FidelidadePremios.IdProduto == 0 || FidelidadePremios.Pontos < 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFidelidadePremios.Add(FidelidadePremios)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaFidelidadePremiosPorId/{id}")]
        public async Task<JsonResult> RetornaFidelidadePremiosPorId(int id)
        {
            return Json(await this.IFidelidadePremios.GetEntityById(id));
        }

        [HttpPost("/api/EditarFidelidadePremios")]
        public async Task<JsonResult> EditarFidelidadePremios([FromBody] FidelidadePremios FidelidadePremios)
        {
            if (FidelidadePremios.IdFidelidade == 0 || FidelidadePremios.IdGrupo == 0 || FidelidadePremios.IdProduto == 0 || FidelidadePremios.Pontos < 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFidelidadePremios.Update(FidelidadePremios)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirFidelidadePremios")]
        public async Task ExcluirFidelidadePremios([FromBody] FidelidadePremios FidelidadePremios)
        {
            await Task.FromResult(this.IFidelidadePremios.Delete(FidelidadePremios));
        }
    }
}
