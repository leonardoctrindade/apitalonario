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
    public class EtapaApiController : Controller
    {
        private readonly IEtapa IEtapa;

        public EtapaApiController(IEtapa iEtapa)
        {
            IEtapa = iEtapa;
        }   

        [HttpGet("/api/ListaEtapa")]
        public async Task<JsonResult> ListaEtapa()
        {
            try
            {
                return Json(await this.IEtapa.List());
            }
            catch (Exception e)
            {

                return Json(BadRequest(ModelState));
            }
        }

        [HttpPost("/api/AdicionarEtapa")]
        public async Task<JsonResult> AdicionarEtapa([FromBody] Etapa etapa)
        {
            try
            {
                if (string.IsNullOrEmpty(etapa.Descricao) || etapa.Sequencia <= 0
                || string.IsNullOrEmpty(etapa.Tipo))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEtapa.Add(etapa)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a etapa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarEtapaPorId/{id}")]
        public async Task<JsonResult> RetornarEtapaPorId(int id)
        {
            try
            {
                return Json(await this.IEtapa.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a etapa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEtapa")]
        public async Task<JsonResult> EditarEtapa([FromBody] Etapa etapa)
        {
            try
            {
                if (string.IsNullOrEmpty(etapa.Descricao) || etapa.Sequencia <= 0
                || string.IsNullOrEmpty(etapa.Tipo))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEtapa.Update(etapa)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a etapa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEtapa")]
        public async Task<JsonResult> ExcluirEtapa([FromBody] Etapa etapa)
        {
            try
            {
                Json(await Task.FromResult(this.IEtapa.Delete(etapa)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a etapa " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
