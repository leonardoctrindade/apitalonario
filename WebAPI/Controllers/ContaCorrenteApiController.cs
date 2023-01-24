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

        [HttpGet("/api/ListaPaginacaoContaCorrente/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var contascorrentes = await this.iContaCorrente.List();

                var total = Convert.ToDouble(contascorrentes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.iContaCorrente.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : contascorrentes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as contas correntes " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarContaCorrente([FromBody] ContaCorrente contaCorrente)
        {
            try
            {
                if (string.IsNullOrEmpty(contaCorrente.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");
                if (string.IsNullOrEmpty(contaCorrente.NumeroConta.Trim()))
                    return BadRequest("Campo de numero da conta é obrigatório");

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
        public async Task<IActionResult> EditarContaCorrente([FromBody] ContaCorrente contaCorrente)
        {
            try
            {
                if (string.IsNullOrEmpty(contaCorrente.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");
                if (string.IsNullOrEmpty(contaCorrente.NumeroConta.Trim()))
                    return BadRequest("Campo de numero da conta é obrigatório");

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
