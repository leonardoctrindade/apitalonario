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
    public class HabitosClienteApiController : Controller
    {
        private readonly IHabitosCliente IHabitosCliente;

        public HabitosClienteApiController(IHabitosCliente IHabitosCliente)
        {
            this.IHabitosCliente = IHabitosCliente;
        }

        [HttpGet("/api/ListaHabitosCliente")]
        public async Task<JsonResult> ListaHabitosCliente()
        {
            try
            {
                return Json(await this.IHabitosCliente.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os habitos do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarHabitosCliente")]
        public async Task<JsonResult> AdicionarHabitosCliente([FromBody] HabitosCliente HabitosCliente)
        {
            try
            {
                if (HabitosCliente.ClienteId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IHabitosCliente.Add(HabitosCliente)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o habitos cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaHabitosClientePorId/{id}")]
        public async Task<JsonResult> RetornaHabitosClientePorId(int id)
        {
            try
            {
                return Json(await this.IHabitosCliente.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o habitos cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarHabitosCliente")]
        public async Task<JsonResult> EditarHabitosCliente([FromBody] HabitosCliente HabitosCliente)
        {
            try
            {
                if (HabitosCliente.ClienteId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IHabitosCliente.Update(HabitosCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o habitos cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirHabitosCliente")]
        public async Task<JsonResult> ExcluirHabitosCliente([FromBody] HabitosCliente HabitosCliente)
        {
            try
            {
                Json(await Task.FromResult(this.IHabitosCliente.Delete(HabitosCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o habitos cliente " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
