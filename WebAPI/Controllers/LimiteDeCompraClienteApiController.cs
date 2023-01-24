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
    public class LimiteDeCompraClienteApiController : Controller
    {
        private readonly ILimiteDeCompraCliente ILimiteDeCompraCliente;

        public LimiteDeCompraClienteApiController(ILimiteDeCompraCliente ILimiteDeCompraCliente)
        {
            this.ILimiteDeCompraCliente = ILimiteDeCompraCliente;
        }

        [HttpGet("/api/ListaPaginacaoLimiteDeCompra/{pagina}")]
        public async Task<IActionResult> ListaPaginacao(int pagina)
        {
            try
            {
                var limitesDeCompraClientes = await this.ILimiteDeCompraCliente.List();

                var total = Convert.ToDouble(limitesDeCompraClientes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ILimiteDeCompraCliente.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : limitesDeCompraClientes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os limites de compra dos clientes " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaLimiteDeCompraCliente")]
        public async Task<JsonResult> ListaLimiteDeCompraCliente()
        {
            try
            {
                return Json(await this.ILimiteDeCompraCliente.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar limites de compra cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarLimiteDeCompraCliente")]
        public async Task<IActionResult> AdicionarLimiteDeCompraCliente([FromBody] LimiteDeCompraCliente LimiteDeCompraCliente)
        {
            try
            {
                if (LimiteDeCompraCliente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");

                Json(await Task.FromResult(this.ILimiteDeCompraCliente.Add(LimiteDeCompraCliente)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o limite de compra cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaLimiteDeCompraClientePorId/{id}")]
        public async Task<JsonResult> RetornaLimiteDeCompraClientePorId(int id)
        {
            try
            {
                return Json(await this.ILimiteDeCompraCliente.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o limite de compra cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarLimiteDeCompraCliente")]
        public async Task<IActionResult> EditarLimiteDeCompraCliente([FromBody] LimiteDeCompraCliente LimiteDeCompraCliente)
        {
            try
            {
                if (LimiteDeCompraCliente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");

                Json(await Task.FromResult(this.ILimiteDeCompraCliente.Update(LimiteDeCompraCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o limite de compra cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirLimiteDeCompraCliente")]
        public async Task<JsonResult> ExcluirLimiteDeCompraCliente([FromBody] LimiteDeCompraCliente LimiteDeCompraCliente)
        {
            try
            {
                Json(await Task.FromResult(this.ILimiteDeCompraCliente.Delete(LimiteDeCompraCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o limite de compra cliente " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
