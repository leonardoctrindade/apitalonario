using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.Controllers
{
    public class UnidadeApiController : Controller
    {
        private readonly IUnidade IUnidade;

        public UnidadeApiController(IUnidade iunidade)
        {
            this.IUnidade = iunidade;
        }

        [HttpGet("/api/ListaUnidade")]
        public async Task<JsonResult> ListaUnidade()
        {
            try
            {
                return Json(await this.IUnidade.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as unidades " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarUnidade")]
        public async Task<JsonResult> AdicionarUnidade([FromBody] Unidade unidade)
        {
            if (string.IsNullOrEmpty(unidade.Sigla) || string.IsNullOrEmpty(unidade.Descricao))
                return Json(BadRequest(ModelState));
            try
            {
                Json(await Task.FromResult(this.IUnidade.Add(unidade)));
                
                return Json(Ok());
            }
            catch (Exception)
            {

                return Json(BadRequest(ModelState));
            }
        }

        [HttpGet("/api/RetornarUnidadePorId/{id}")]
        public async Task<JsonResult> RetornarUnidadeProId(int id)
        {
            try
            {
                if (id == 0)
                    return Json(BadRequest(ModelState));

                return Json(await this.IUnidade.GetUnidade(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a unidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarUnidade")]
        public async Task<JsonResult> EditarUnidade([FromBody] Unidade unidade)
        {
            try
            {
                if (string.IsNullOrEmpty(unidade.Sigla) || string.IsNullOrEmpty(unidade.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IUnidade.Update(unidade)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a unidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirUnidade")]
        public async Task<JsonResult> ExcluirUnidade([FromBody] Unidade unidade)
        {
            try
            {
                return Json(await Task.FromResult(this.IUnidade.Delete(unidade)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a unidade " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
