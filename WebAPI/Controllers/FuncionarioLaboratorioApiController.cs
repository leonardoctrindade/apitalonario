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
            try
            {
                return Json(await this.IFuncionarioLaboratorio.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os funcionarios do laboratorio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFuncionarioLaboratorio")]
        public async Task<JsonResult> AdicionarFuncionarioLaboratorio([FromBody] FuncionarioLaboratorio FuncionarioLaboratorio)
        {
            try
            {
                if (String.IsNullOrEmpty(FuncionarioLaboratorio.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFuncionarioLaboratorio.Add(FuncionarioLaboratorio)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o funcionario do laboratorio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFuncionarioLaboratorioPorId/{id}")]
        public async Task<JsonResult> RetornaFuncionarioLaboratorioPorId(int id)
        {
            try
            {
                return Json(await this.IFuncionarioLaboratorio.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o funcionario do laboratorio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFuncionarioLaboratorio")]
        public async Task<JsonResult> EditarFuncionarioLaboratorio([FromBody] FuncionarioLaboratorio FuncionarioLaboratorio)
        {
            try
            {
                if (String.IsNullOrEmpty(FuncionarioLaboratorio.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFuncionarioLaboratorio.Update(FuncionarioLaboratorio)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o funcionario do laboratorio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFuncionarioLaboratorio")]
        public async Task<JsonResult> ExcluirFuncionarioLaboratorio([FromBody] FuncionarioLaboratorio FuncionarioLaboratorio)
        {
            try
            {
                return Json(await Task.FromResult(this.IFuncionarioLaboratorio.Delete(FuncionarioLaboratorio)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o funcionario do laboratorio " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
