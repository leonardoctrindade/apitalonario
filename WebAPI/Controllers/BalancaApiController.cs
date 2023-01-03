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
        public async Task<JsonResult> AdicionarBalanca([FromBody] Balanca Balanca)
        {
            try
            {
                if (String.IsNullOrEmpty(Balanca.Modelo))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Balanca.PortaCom))
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarBalanca([FromBody] Balanca Balanca)
        {
            try
            {
                if (String.IsNullOrEmpty(Balanca.Modelo))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Balanca.PortaCom))
                    return Json(BadRequest(ModelState));

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
                return Json(await Task.FromResult(this.IBalanca.Delete(Balanca)));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a balanca " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
