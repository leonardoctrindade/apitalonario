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
    public class NfeExpedicaoClienteApiController : Controller
    {
        private readonly INfeExpedicaoCliente INfeExpedicaoCliente;

        public NfeExpedicaoClienteApiController(INfeExpedicaoCliente INfeExpedicaoCliente)
        {
            this.INfeExpedicaoCliente = INfeExpedicaoCliente;
        }

        [HttpGet("/api/ListaPaginacaoNfeExpedicaoCliente/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var nfes = await this.INfeExpedicaoCliente.List();

                var total = Convert.ToDouble(nfes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.INfeExpedicaoCliente.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : nfes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os nfes de expedição do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaNfeExpedicaoCliente")]
        public async Task<JsonResult> ListaNfeExpedicaoCliente()
        {
            try
            {
                return Json(await this.INfeExpedicaoCliente.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as Nfe/Expedicao do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarNfeExpedicaoCliente")]
        public async Task<IActionResult> AdicionarNfeExpedicaoCliente([FromBody] NfeExpedicaoCliente NfeExpedicaoCliente)
        {
            try
            {
                if (NfeExpedicaoCliente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");

                Json(await Task.FromResult(this.INfeExpedicaoCliente.Add(NfeExpedicaoCliente)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a Nfe/Expedicao do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaNfeExpedicaoClientePorId/{id}")]
        public async Task<JsonResult> RetornaNfeExpedicaoClientePorId(int id)
        {
            try
            {
                return Json(await this.INfeExpedicaoCliente.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a Nfe/Expedicao do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarNfeExpedicaoCliente")]
        public async Task<IActionResult> EditarNfeExpedicaoCliente([FromBody] NfeExpedicaoCliente NfeExpedicaoCliente)
        {
            try
            {
                if (NfeExpedicaoCliente.ClienteId <= 0)
                    return BadRequest("Campo de cliente é obrigatório");

                Json(await Task.FromResult(this.INfeExpedicaoCliente.Update(NfeExpedicaoCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a Nfe/Expedicao do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirNfeExpedicaoCliente")]
        public async Task<JsonResult> ExcluirNfeExpedicaoCliente([FromBody] NfeExpedicaoCliente NfeExpedicaoCliente)
        {
            try
            {
                Json(await Task.FromResult(this.INfeExpedicaoCliente.Delete(NfeExpedicaoCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a Nfe/Expedicao do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
