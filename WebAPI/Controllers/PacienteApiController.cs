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

        [HttpGet("/api/ListaPaginacaoPaciente/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var pacientes = await this.IPaciente.List();

                var total = Convert.ToDouble(pacientes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IPaciente.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : pacientes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os pacientes " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarPaciente([FromBody] Paciente Paciente)
        {
            try
            {
                if (Paciente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");
                if (string.IsNullOrEmpty(Paciente.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

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
        public async Task<IActionResult> EditarPaciente([FromBody] Paciente Paciente)
        {
            try
            {
                if (Paciente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");
                if (string.IsNullOrEmpty(Paciente.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

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
