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
    public class PrincipioAtivoApiController : Controller
    {
        private readonly IPrincipioAtivo IPrincipioAtivo;

        public PrincipioAtivoApiController(IPrincipioAtivo iprincipioAtivo)
        {
            IPrincipioAtivo = iprincipioAtivo;
        }

        [HttpGet("/api/ListaPaginacaoPrincipioAtivo/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var principios = await this.IPrincipioAtivo.List();

                var total = Convert.ToDouble(principios.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IPrincipioAtivo.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : principios);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os principios ativos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaPrincipioAtivo")]
        public async Task<JsonResult> ListaPrincipioAtivo()
        {
            try
            {
                return Json(await this.IPrincipioAtivo.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os principios ativos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarPrincipioAtivo")]
        public async Task<IActionResult> AdicionarPrincipioAtivo([FromBody] PrincipioAtivo principioAtivo)
        {
            try
            {
                if (string.IsNullOrEmpty(principioAtivo.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IPrincipioAtivo.Add(principioAtivo)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o principio ativo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarPrincipioAtivoProId/{id}")]
        public async Task<JsonResult> RetornarPrincipioAtivoProId(int id)
        {
            try
            {
                if (id == 0)
                    return Json(BadRequest(ModelState));
                return Json(await this.IPrincipioAtivo.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o principio ativo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPrincipioAtivo")]
        public async Task<IActionResult> EditarPrincipioAtivo([FromBody] PrincipioAtivo principioAtivo)
        {
            try
            {
                if (string.IsNullOrEmpty(principioAtivo.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IPrincipioAtivo.Update(principioAtivo)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o principio ativo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPrincipioAtivo")]
        public async Task<JsonResult> ExcluirPrincipioAtivo([FromBody] PrincipioAtivo principioAtivo)
        {
            try
            {
                Json(await Task.FromResult(this.IPrincipioAtivo.Delete(principioAtivo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o principio ativo " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
