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
    public class VisitadorApiController : Controller
    {
        private readonly IVisitador IVisitador;

        public VisitadorApiController(IVisitador iVisitador)
        {
            IVisitador = iVisitador;
        }

        [HttpGet("/api/ListaVisitador")]
        public async Task<JsonResult> ListaVisitador()
        {
            return Json(await this.IVisitador.List());
        }
        [HttpPost("/api/AdicionarVisitador")]
        public async Task<JsonResult> AdicionarVisitador([FromBody] Visitador visitador)
        {
            if (string.IsNullOrEmpty(visitador.Nome))
                return Json(BadRequest(ModelState));

            try
            {
                Json(await Task.FromResult(this.IVisitador.Add(visitador)));

            }
            catch (Exception)
            {

                throw;
            }


            return Json(Ok());
        }
        [HttpGet("/api/RetornarVisitadorPorId/{id}")]
        public async Task<JsonResult> RetornarVisitadorPorId(int id)
        {
            return Json(await this.IVisitador.GetEntityById(id));
        }
        [HttpPost("/api/EditarVisitador")]
        public async Task<JsonResult> EditarVisitador([FromBody] Visitador visitador)
        {
            if (string.IsNullOrEmpty(visitador.Nome))
                return Json(BadRequest(ModelState));

            try
            {
                Json(await Task.FromResult(this.IVisitador.Update(visitador)));

            }
            catch (Exception)
            {

                throw;
            }


            return Json(Ok());
        }
        [HttpPost("/api/ExcluirVisitador")]
        public async Task ExcluirVisitador([FromBody] Visitador visitador)
        {
            await Task.FromResult(this.IVisitador.Delete(visitador));
        }
    }
}
