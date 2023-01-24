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

        [HttpGet("/api/ListaPaginacaoConvenioCliente/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var conveniosCliente = await this.IConvenioCliente.List();

                var total = Convert.ToDouble(conveniosCliente.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IConvenioCliente.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : conveniosCliente);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os convenios cliente " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarConvenioCliente([FromBody] ConvenioCliente ConvenioCliente)
        {
            try
            {
                if (ConvenioCliente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");
                if (ConvenioCliente.ConvenioId <= 0)
                    return BadRequest("Campo de Convenio é obrigatório");

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
        public async Task<IActionResult> EditarConvenioCliente([FromBody] ConvenioCliente ConvenioCliente)
        {
            try
            {
                if (ConvenioCliente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");
                if (ConvenioCliente.ConvenioId <= 0)
                    return BadRequest("Campo de Convenio é obrigatório");

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
