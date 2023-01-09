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
    public class PacienteApiController : Controller
    {
        private readonly IPaciente IPaciente;

        public PacienteApiController(IPaciente IPaciente)
        {
            this.IPaciente = IPaciente;
        }

        [HttpGet("/api/ListaPaciente")]
        public async Task<JsonResult> ListaPaciente()
        {
            try
            {
                return Json(await this.IPaciente.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os pacientes " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarPaciente")]
        public async Task<JsonResult> AdicionarPaciente([FromBody] Paciente Paciente)
        {
            try
            {
                if (Paciente.ClienteId <= 0 || string.IsNullOrEmpty(Paciente.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPaciente.Add(Paciente)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o paciente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaPacientePorId/{id}")]
        public async Task<JsonResult> RetornaPacientePorId(int id)
        {
            try
            {
                return Json(await this.IPaciente.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o paciente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPaciente")]
        public async Task<JsonResult> EditarPaciente([FromBody] Paciente Paciente)
        {
            try
            {
                if (Paciente.ClienteId <= 0 || string.IsNullOrEmpty(Paciente.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPaciente.Update(Paciente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o paciente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPaciente")]
        public async Task<JsonResult> ExcluirPaciente([FromBody] Paciente Paciente)
        {
            try
            {
                Json(await Task.FromResult(this.IPaciente.Delete(Paciente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o paciente " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
