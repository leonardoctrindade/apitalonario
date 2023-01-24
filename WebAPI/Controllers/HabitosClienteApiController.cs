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

        [HttpGet("/api/ListaPaginacaoPbm/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var habitosClientes = await this.IHabitosCliente.List();

                var total = Convert.ToDouble(habitosClientes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IHabitosCliente.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : habitosClientes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os habitos dos clientes " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarHabitosCliente([FromBody] HabitosCliente HabitosCliente)
        {
            try
            {
                if (HabitosCliente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");

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
        public async Task<IActionResult> EditarHabitosCliente([FromBody] HabitosCliente HabitosCliente)
        {
            try
            {
                if (HabitosCliente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");

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
