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
        public async Task<JsonResult> AdicionarPrincipioAtivo([FromBody] PrincipioAtivo principioAtivo)
        {
            try
            {
                if (string.IsNullOrEmpty(principioAtivo.Descricao))
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarPrincipioAtivo([FromBody] PrincipioAtivo principioAtivo)
        {
            try
            {
                if (string.IsNullOrEmpty(principioAtivo.Descricao))
                    return Json(BadRequest(ModelState));

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
                return Json(await Task.FromResult(this.IPrincipioAtivo.Delete(principioAtivo)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o principio ativo " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
