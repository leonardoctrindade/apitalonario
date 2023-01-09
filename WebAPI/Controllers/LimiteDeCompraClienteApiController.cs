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
        public async Task<JsonResult> AdicionarLimiteDeCompraCliente([FromBody] LimiteDeCompraCliente LimiteDeCompraCliente)
        {
            try
            {
                if (LimiteDeCompraCliente.ClienteId <= 0)
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarLimiteDeCompraCliente([FromBody] LimiteDeCompraCliente LimiteDeCompraCliente)
        {
            try
            {
                if (LimiteDeCompraCliente.ClienteId <= 0)
                    return Json(BadRequest(ModelState));

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
