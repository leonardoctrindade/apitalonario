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
        public async Task<JsonResult> AdicionarCliente([FromBody] Cliente Cliente)
        {
            try
            {
                if (String.IsNullOrEmpty(Cliente.Nome))
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarCliente([FromBody] Cliente Cliente)
        {
            try
            {
                if (String.IsNullOrEmpty(Cliente.Nome))
                    return Json(BadRequest(ModelState));

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
