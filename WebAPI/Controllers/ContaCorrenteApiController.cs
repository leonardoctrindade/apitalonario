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
    public class ContaCorrenteApiController : Controller
    {
        private readonly IContaCorrente iContaCorrente;
        public ContaCorrenteApiController(IContaCorrente icontacorrente)
        {
            iContaCorrente = icontacorrente;
        }

        [HttpGet("/api/ListarContaCorrente")]
        public async Task<JsonResult> ListarContaCorrente()
        {
            try
            {
                return Json(await this.iContaCorrente.List());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as contas correntes " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarContaCorrente")]
        public async Task<JsonResult> AdicionarContaCorrente([FromBody] ContaCorrente contaCorrente)
        {
            try
            {
                if (string.IsNullOrEmpty(contaCorrente.Nome) || string.IsNullOrEmpty(contaCorrente.NumeroConta))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.iContaCorrente.Add(contaCorrente)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a conta corrente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarContaCorrentePorId/{id}")]
        public async Task<JsonResult> RetornarContaCorrentePorId(int id)
        {
            try
            {
                return Json(await this.iContaCorrente.GetEntityById(id));
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar a conta corrente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarContaCorrente")]
        public async Task<JsonResult> EditarContaCorrente([FromBody] ContaCorrente contaCorrente)
        {
            try
            {
                if (string.IsNullOrEmpty(contaCorrente.Nome) || string.IsNullOrEmpty(contaCorrente.NumeroConta))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.iContaCorrente.Update(contaCorrente)));

                return Json(Ok());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a conta corrente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("api/ExcluirContaCorrente")]
        public async Task<JsonResult> ExcluirContaCorrente([FromBody] ContaCorrente contaCorrente)
        {
            try
            {
                Json(await Task.FromResult(this.iContaCorrente.Delete(contaCorrente)));
                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir a conta corrente " + ex.Message }) { StatusCode = 400 };
            }
        }

    }
}
