using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class EspecialidadeApiController: Controller
    {
        private readonly IEspecialidade IEspecialidade;

        public EspecialidadeApiController(IEspecialidade IEspecialidade)
        {
            this.IEspecialidade = IEspecialidade;
        }

        [HttpGet("/api/ListaEspecialidade")]
        public async Task<JsonResult> ListaEspecialidade()
        {
            return Json(await this.IEspecialidade.List());
        }

        [HttpPost("/api/AdicionarEspecialidade")]
        public async Task<JsonResult> AdicionarEspecialidade([FromBody] Especialidade Especialidade)
        {
            if (String.IsNullOrEmpty(Especialidade.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEspecialidade.Add(Especialidade)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaEspecialidadeorId/{id}")]
        public async Task<JsonResult> RetornaEspecialidadePorId(int id)
        {
            return Json(await this.IEspecialidade.GetEntityById(id));
        }

        [HttpPost("/api/EditarEspecialidade")]
        public async Task<JsonResult> EditarEspecialidade([FromBody] Especialidade Especialidade)
        {
            if (String.IsNullOrEmpty(Especialidade.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEspecialidade.Update(Especialidade)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirEspecialidade")]
        public async Task ExcluirEspecialidade([FromBody] Especialidade Especialidade)
        {
            await Task.FromResult(this.IEspecialidade.Delete(Especialidade));
        }
    }
}
