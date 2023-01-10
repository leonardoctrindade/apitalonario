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
    public class EnderecoEntregaClienteApiController : Controller
    {
        private readonly IEnderecoEntregaCliente IEnderecoEntregaCliente;

        public EnderecoEntregaClienteApiController(IEnderecoEntregaCliente IEnderecoEntregaCliente)
        {
            this.IEnderecoEntregaCliente = IEnderecoEntregaCliente;
        }

        [HttpGet("/api/ListaEnderecoEntregaCliente")]
        public async Task<JsonResult> ListaEnderecoEntregaCliente()
        {
            try
            {
                return Json(await this.IEnderecoEntregaCliente.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os endereços de entrega do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEnderecoEntregaCliente")]
        public async Task<JsonResult> AdicionarEnderecoEntregaCliente([FromBody] EnderecoEntregaCliente EnderecoEntregaCliente)
        {
            try
            {
                if (EnderecoEntregaCliente.ClienteId <= 0 || string.IsNullOrEmpty(EnderecoEntregaCliente.Titulo) || string.IsNullOrEmpty(EnderecoEntregaCliente.Endereco)) 
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEnderecoEntregaCliente.Add(EnderecoEntregaCliente)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o endereço de entrega do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaEnderecoEntregaClientePorId/{id}")]
        public async Task<JsonResult> RetornaEnderecoEntregaClientePorId(int id)
        {
            try
            {
                return Json(await this.IEnderecoEntregaCliente.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o endereço de entrega do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEnderecoEntregaCliente")]
        public async Task<JsonResult> EditarEnderecoEntregaCliente([FromBody] EnderecoEntregaCliente EnderecoEntregaCliente)
        {
            try
            {
                if (EnderecoEntregaCliente.ClienteId <= 0 || string.IsNullOrEmpty(EnderecoEntregaCliente.Titulo) || string.IsNullOrEmpty(EnderecoEntregaCliente.Endereco))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEnderecoEntregaCliente.Update(EnderecoEntregaCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o endereço de entrega do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEnderecoEntregaCliente")]
        public async Task<JsonResult> ExcluirEnderecoEntregaCliente([FromBody] EnderecoEntregaCliente EnderecoEntregaCliente)
        {
            try
            {
                Json(await Task.FromResult(this.IEnderecoEntregaCliente.Delete(EnderecoEntregaCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o endereço de entrega do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
