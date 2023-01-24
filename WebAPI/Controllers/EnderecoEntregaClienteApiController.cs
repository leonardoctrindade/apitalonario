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

        [HttpGet("/api/ListaPaginacaoEnderecoEntregaCliente/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var enderecosDeEntregasCliente = await this.IEnderecoEntregaCliente.List();

                var total = Convert.ToDouble(enderecosDeEntregasCliente.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IEnderecoEntregaCliente.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : enderecosDeEntregasCliente);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os pbms " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarEnderecoEntregaCliente([FromBody] EnderecoEntregaCliente EnderecoEntregaCliente)
        {
            try
            {
                if (EnderecoEntregaCliente.ClienteId <= 0) 
                    return BadRequest("Campo de cliente é obrigatório");
                if (string.IsNullOrEmpty(EnderecoEntregaCliente.Titulo.Trim()))
                    return BadRequest("Campo de título é obrigatório");
                if (string.IsNullOrEmpty(EnderecoEntregaCliente.Endereco.Trim()))
                    return BadRequest("Campo de endereço é obrigatório");

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
        public async Task<IActionResult> EditarEnderecoEntregaCliente([FromBody] EnderecoEntregaCliente EnderecoEntregaCliente)
        {
            try
            {
                if (EnderecoEntregaCliente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");
                if (string.IsNullOrEmpty(EnderecoEntregaCliente.Titulo.Trim()))
                    return BadRequest("Campo de título é obrigatório");
                if (string.IsNullOrEmpty(EnderecoEntregaCliente.Endereco.Trim()))
                    return BadRequest("Campo de endereço é obrigatório");

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
