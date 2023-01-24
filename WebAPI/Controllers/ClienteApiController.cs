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
    public class ClienteApiController : Controller
    {
        private readonly ICliente ICliente;

        public ClienteApiController(ICliente ICliente)
        {
            this.ICliente = ICliente;
        }

        [HttpGet("/api/ListaPaginacaoCliente/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var clientes = await this.ICliente.List();

                var total = Convert.ToDouble(clientes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ICliente.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : clientes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os pbms " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaCliente")]
        public async Task<JsonResult> ListaCliente()
        {
            try
            {
                return Json(await this.ICliente.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os clientes " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarCliente")]
        public async Task<IActionResult> AdicionarCliente([FromBody] Cliente Cliente)
        {
            try
            {
                if (String.IsNullOrEmpty(Cliente.Nome.Trim()))
                    return BadRequest("Campo de nome não preenchido");

                Json(await Task.FromResult(this.ICliente.Add(Cliente)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaClientePorId/{id}")]
        public async Task<JsonResult> RetornaClientePorId(int id)
        {
            try
            {
                return Json(await this.ICliente.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarCliente")]
        public async Task<IActionResult> EditarCliente([FromBody] Cliente Cliente)
        {
            try
            {
                if (String.IsNullOrEmpty(Cliente.Nome.Trim()))
                    return BadRequest("Campo de nome não preenchido");

                Json(await Task.FromResult(this.ICliente.Update(Cliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirCliente")]
        public async Task<JsonResult> ExcluirCliente([FromBody] Cliente Cliente)
        {
            try
            {
                Json(await Task.FromResult(this.ICliente.Delete(Cliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o cliente " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
