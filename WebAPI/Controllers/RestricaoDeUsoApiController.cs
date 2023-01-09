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
    public class RestricaoDeUsoApiController: Controller
    {
        private readonly IRestricaoDeUso IRestricaoDeUso;

        public RestricaoDeUsoApiController(IRestricaoDeUso IRestricaoDeUso)
        {
            this.IRestricaoDeUso = IRestricaoDeUso;
        }

        [HttpGet("/api/ListaRestricaoDeUso")]
        public async Task<JsonResult> ListaRestricaoDeUso()
        {
            try
            {
                return Json(await this.IRestricaoDeUso.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as restricoes de uso" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarRestricaoDeUso")]
        public async Task<JsonResult> AdicionarRestricaoDeUso([FromBody] RestricaoDeUso RestricaoDeUso)
        {
            try
            {
                if (RestricaoDeUso.ProdutoId <= 0 || RestricaoDeUso.GrupoId <= 0 || RestricaoDeUso.ClienteId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IRestricaoDeUso.Add(RestricaoDeUso)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a restricao de uso " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaRestricaoDeUsoPorId/{id}")]
        public async Task<JsonResult> RetornaRestricaoDeUsoPorId(int id)
        {
            try
            {
                return Json(await this.IRestricaoDeUso.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a restricao de uso " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarRestricaoDeUso")]
        public async Task<JsonResult> EditarRestricaoDeUso([FromBody] RestricaoDeUso RestricaoDeUso)
        {
            try
            {
                if (RestricaoDeUso.ProdutoId <= 0 || RestricaoDeUso.GrupoId <= 0 || RestricaoDeUso.ClienteId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IRestricaoDeUso.Update(RestricaoDeUso)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a restricao de uso " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirRestricaoDeUso")]
        public async Task<JsonResult> ExcluirRestricaoDeUso([FromBody] RestricaoDeUso RestricaoDeUso)
        {
            try
            {
                Json(await Task.FromResult(this.IRestricaoDeUso.Delete(RestricaoDeUso)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a restricao de uso " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
