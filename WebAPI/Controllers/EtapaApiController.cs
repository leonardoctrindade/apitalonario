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
            if (string.IsNullOrEmpty(etapa.Descricao) || etapa.Sequencia <= 0
                || string.IsNullOrEmpty(etapa.Tipo))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEtapa.Add(etapa)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarEtapaPorId/{id}")]
        public async Task<JsonResult> RetornarEtapaPorId(int id)
        {
            return Json(await this.IEtapa.GetEntityById(id));
        }
        [HttpPost("/api/EditarEtapa")]
        public async Task<JsonResult> EditarEtapa([FromBody] Etapa etapa)
        {
            if (string.IsNullOrEmpty(etapa.Descricao) || etapa.Sequencia <= 0
                || string.IsNullOrEmpty(etapa.Tipo))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEtapa.Update(etapa)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirEtapa")]
        public async Task ExcluirEtapa([FromBody] Etapa etapa)
        {
            await Task.FromResult(this.IEtapa.Delete(etapa));
        }
    }
}
