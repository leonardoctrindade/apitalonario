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
    public class ConvenioClienteApiController : Controller
    {
        private readonly IConvenioCliente IConvenioCliente;

        public ConvenioClienteApiController(IConvenioCliente IConvenioCliente)
        {
            this.IConvenioCliente = IConvenioCliente;
        }

        [HttpGet("/api/ListaConvenioCliente")]
        public async Task<JsonResult> ListaConvenioCliente()
        {
            try
            {
                return Json(await this.IConvenioCliente.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os convenios cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarConvenioCliente")]
        public async Task<JsonResult> AdicionarConvenioCliente([FromBody] ConvenioCliente ConvenioCliente)
        {
            try
            {
                if (ConvenioCliente.ClienteId <= 0 || ConvenioCliente.ConvenioId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IConvenioCliente.Add(ConvenioCliente)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o convenio cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaConvenioClientePorId/{id}")]
        public async Task<JsonResult> RetornaConvenioClientePorId(int id)
        {
            try
            {
                return Json(await this.IConvenioCliente.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o convenio cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarConvenioCliente")]
        public async Task<JsonResult> EditarConvenioCliente([FromBody] ConvenioCliente ConvenioCliente)
        {
            try
            {
                if (ConvenioCliente.ClienteId <= 0 || ConvenioCliente.ConvenioId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IConvenioCliente.Update(ConvenioCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o convenio cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirConvenioCliente")]
        public async Task<JsonResult> ExcluirConvenioCliente([FromBody] ConvenioCliente ConvenioCliente)
        {
            try
            {
                Json(await Task.FromResult(this.IConvenioCliente.Delete(ConvenioCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o convenio cliente " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
