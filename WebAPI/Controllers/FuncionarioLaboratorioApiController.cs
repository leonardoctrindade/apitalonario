using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class FuncionarioLaboratorioApiController: Controller
    {
        private readonly IFuncionarioLaboratorio IFuncionarioLaboratorio;

        public FuncionarioLaboratorioApiController(IFuncionarioLaboratorio IFuncionarioLaboratorio)
        {
            this.IFuncionarioLaboratorio = IFuncionarioLaboratorio;
        }

        [HttpGet("/api/ListaFuncionarioLaboratorio")]
        public async Task<JsonResult> ListaFuncionarioLaboratorio()
        {
            return Json(await this.IFuncionarioLaboratorio.List());
        }

        [HttpPost("/api/AdicionarFuncionarioLaboratorio")]
        public async Task<JsonResult> AdicionarFuncionarioLaboratorio([FromBody] FuncionarioLaboratorio FuncionarioLaboratorio)
        {
            if (String.IsNullOrEmpty(FuncionarioLaboratorio.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFuncionarioLaboratorio.Add(FuncionarioLaboratorio)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaFuncionarioLaboratorioPorId/{id}")]
        public async Task<JsonResult> RetornaFuncionarioLaboratorioPorId(int id)
        {
            return Json(await this.IFuncionarioLaboratorio.GetEntityById(id));
        }

        [HttpPost("/api/EditarFuncionarioLaboratorio")]
        public async Task<JsonResult> EditarFuncionarioLaboratorio([FromBody] FuncionarioLaboratorio FuncionarioLaboratorio)
        {
            if (String.IsNullOrEmpty(FuncionarioLaboratorio.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFuncionarioLaboratorio.Update(FuncionarioLaboratorio)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirFuncionarioLaboratorio")]
        public async Task ExcluirFuncionarioLaboratorio([FromBody] FuncionarioLaboratorio FuncionarioLaboratorio)
        {
            await Task.FromResult(this.IFuncionarioLaboratorio.Delete(FuncionarioLaboratorio));
        }
    }
}
