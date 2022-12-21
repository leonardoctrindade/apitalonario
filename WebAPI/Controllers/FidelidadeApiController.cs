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
    public class FidelidadeApiController: Controller
    {
        private readonly IFidelidade IFidelidade;

        public FidelidadeApiController(IFidelidade IFidelidade)
        {
            this.IFidelidade = IFidelidade;
        }

        [HttpGet("/api/ListaFidelidade")]
        public async Task<JsonResult> ListaFidelidade()
        {
            return Json(await this.IFidelidade.List());
        }

        [HttpPost("/api/AdicionarFidelidade")]
        public async Task<JsonResult> AdicionarFidelidade([FromBody] Fidelidade Fidelidade)
        {
            if (String.IsNullOrEmpty(Fidelidade.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFidelidade.Add(Fidelidade)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaFidelidadePorId/{id}")]
        public async Task<JsonResult> RetornaFidelidadePorId(int id)
        {
            return Json(await this.IFidelidade.GetEntityById(id));
        }

        [HttpPost("/api/EditarFidelidade")]
        public async Task<JsonResult> EditarFidelidade([FromBody] Fidelidade Fidelidade)
        {
            if (String.IsNullOrEmpty(Fidelidade.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFidelidade.Update(Fidelidade)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirFidelidade")]
        public async Task ExcluirFidelidade([FromBody] Fidelidade Fidelidade)
        {
            await Task.FromResult(this.IFidelidade.Delete(Fidelidade));
        }
    }
}
