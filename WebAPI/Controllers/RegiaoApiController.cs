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
    public class RegiaoApiController : Controller
    {
        private readonly IRegiao IRegiao;

        public RegiaoApiController(IRegiao IRegiao)
        {
            this.IRegiao = IRegiao;
        }

        [HttpGet("/api/ListaRegiao")]
        public async Task<JsonResult> ListaRegiao()
        {
            try
            {
                return Json(await this.IRegiao.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as regiões " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarRegiao")]
        public async Task<JsonResult> AdicionarRegiao([FromBody] Regiao Regiao)
        {
            try
            {
                if (String.IsNullOrEmpty(Regiao.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IRegiao.Add(Regiao)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaRegiaoPorId/{id}")]
        public async Task<JsonResult> RetornaRegiaoPorId(int id)
        {
            try
            {
                return Json(await this.IRegiao.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarRegiao")]
        public async Task<JsonResult> EditarRegiao([FromBody] Regiao Regiao)
        {
            try
            {
                if (String.IsNullOrEmpty(Regiao.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IRegiao.Update(Regiao)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirRegiao")]
        public async Task<JsonResult> ExcluirRegiao([FromBody] Regiao Regiao)
        {
            try
            {
                Json(await Task.FromResult(this.IRegiao.Delete(Regiao)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a região " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
