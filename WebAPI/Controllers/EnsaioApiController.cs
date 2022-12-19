using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class EnsaioApiController : Controller
    {
        private readonly IEnsaio IEnsaio;

        public EnsaioApiController(IEnsaio IEnsaio)
        {
            this.IEnsaio = IEnsaio;
        }

        [HttpGet("/api/ListaEnsaio")]
        public async Task<JsonResult> ListaEnsaio()
        {
            return Json(await this.IEnsaio.List());
        }

        [HttpPost("/api/AdicionarEnsaio")]
        public async Task<JsonResult> AdicionarEnsaio([FromBody] Ensaio Ensaio)
        {
            if (String.IsNullOrEmpty(Ensaio.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEnsaio.Add(Ensaio)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaEnsaioPorId/{id}")]
        public async Task<JsonResult> RetornaEnsaioPorId(int id)
        {
            return Json(await this.IEnsaio.GetEntityById(id));
        }

        [HttpPost("/api/EditarEnsaio")]
        public async Task<JsonResult> EditarEnsaio([FromBody] Ensaio Ensaio)
        {
            if (String.IsNullOrEmpty(Ensaio.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEnsaio.Update(Ensaio)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirEnsaio")]
        public async Task ExcluirEnsaio([FromBody] Ensaio Ensaio)
        {
            await Task.FromResult(this.IEnsaio.Delete(Ensaio));
        }
    }
}
