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
    public class CidadeApiController : Controller
    {
        private readonly ICidade ICidade;

        public CidadeApiController(ICidade ICidade)
        {
            this.ICidade = ICidade;
        }

        [HttpGet("/api/ListaCidade")]
        public async Task<JsonResult> ListaCidade()
        {
            return Json(await this.ICidade.List());
        }

        [HttpPost("/api/AdicionarCidade")]
        public async Task<JsonResult> AdicionarCidade([FromBody] Cidade Cidade)
        {
            if (String.IsNullOrEmpty(Cidade.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ICidade.Add(Cidade)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaCidadePorId/{id}")]
        public async Task<JsonResult> RetornaCidadePorId(int id)
        {
            return Json(await this.ICidade.GetEntityById(id));
        }

        [HttpPost("/api/EditarCidade")]
        public async Task<JsonResult> EditarCidade([FromBody] Cidade Cidade)
        {
            if (String.IsNullOrEmpty(Cidade.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ICidade.Update(Cidade)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirCidade")]
        public async Task ExcluirCidade([FromBody] Cidade Cidade)
        {
            await Task.FromResult(this.ICidade.Delete(Cidade));
        }
    }
}
