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
    public class OperadorCaixaApiController : Controller
    {
        private readonly IOperadorCaixa IOperadorCaixa;

        public OperadorCaixaApiController(IOperadorCaixa IOperadorCaixa)
        {
            this.IOperadorCaixa = IOperadorCaixa;
        }

        [HttpGet("/api/ListaOperadorCaixa")]
        public async Task<JsonResult> ListaOperadorCaixa()
        {
            try
            {
                return Json(await this.IOperadorCaixa.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os operadores de caixa" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarOperadorCaixa")]
        public async Task<JsonResult> AdicionarOperadorCaixa([FromBody] OperadorCaixa OperadorCaixa)
        {
            try
            {
                if (String.IsNullOrEmpty(OperadorCaixa.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IOperadorCaixa.Add(OperadorCaixa)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o operador de caixa" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaOperadorCaixaPorId/{id}")]
        public async Task<JsonResult> RetornaOperadorCaixaPorId(int id)
        {
            try
            {
                return Json(await this.IOperadorCaixa.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o operador de caixa" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarOperadorCaixa")]
        public async Task<JsonResult> EditarOperadorCaixa([FromBody] OperadorCaixa OperadorCaixa)
        {
            try
            {
                if (String.IsNullOrEmpty(OperadorCaixa.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IOperadorCaixa.Update(OperadorCaixa)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o operador de caixa" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirOperadorCaixa")]
        public async Task<JsonResult> ExcluirOperadorCaixa([FromBody] OperadorCaixa OperadorCaixa)
        {
            try
            {
                return Json(await Task.FromResult(this.IOperadorCaixa.Delete(OperadorCaixa)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o operador de caixa" + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
