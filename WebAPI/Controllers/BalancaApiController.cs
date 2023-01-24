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
    public class BalancaApiController : Controller
    {
        private readonly IBalanca IBalanca;

        public BalancaApiController(IBalanca IBalanca)
        {
            this.IBalanca = IBalanca;
        }

        [HttpGet("/api/ListaPaginacaoBalanca/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var balancas = await this.IBalanca.List();

                var total = Convert.ToDouble(balancas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IBalanca.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : balancas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as balanças " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaBalanca")]
        public async Task<JsonResult> ListaBalanca()
        {
            try
            {
                return Json(await this.IBalanca.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as balanca " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarBalanca")]
        public async Task<IActionResult> AdicionarBalanca([FromBody] Balanca Balanca)
        {
            try
            {
                if (String.IsNullOrEmpty(Balanca.Modelo.Trim()))
                    return BadRequest("Campo de modelo é obrigatório");
                if (String.IsNullOrEmpty(Balanca.PortaCom.Trim()))
                    return BadRequest("Campo de portaCom é obrigatório");

                Json(await Task.FromResult(this.IBalanca.Add(Balanca)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a balanca " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaBalancaPorId/{id}")]
        public async Task<JsonResult> RetornaBalancaPorId(int id)
        {
            try
            {
                return Json(await this.IBalanca.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a balanca " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarBalanca")]
        public async Task<IActionResult> EditarBalanca([FromBody] Balanca Balanca)
        {
            try
            {
                if (String.IsNullOrEmpty(Balanca.Modelo.Trim()))
                    return BadRequest("Campo de modelo é obrigatório");
                if (String.IsNullOrEmpty(Balanca.PortaCom.Trim()))
                    return BadRequest("Campo de portaCom é obrigatório");

                Json(await Task.FromResult(this.IBalanca.Update(Balanca)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a balanca " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirBalanca")]
        public async Task<JsonResult> ExcluirBalanca([FromBody] Balanca Balanca)
        {
            try
            {
                Json(await Task.FromResult(this.IBalanca.Delete(Balanca)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a balanca " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
