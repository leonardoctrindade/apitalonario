using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class PaisApiController : Controller
    {
        private readonly IPais IPais;

        public PaisApiController(IPais IPais)
        {
            this.IPais = IPais;
        }

        [HttpGet("/api/ListaPais")]
        public async Task<JsonResult> ListaPais()
        {
            return Json(await this.IPais.List());
        }

        [HttpPost("/api/AdicionarPais")]
        public async Task<JsonResult> AdicionarPais([FromBody] Pais Pais)
        {
            if (String.IsNullOrEmpty(Pais.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPais.Add(Pais)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaPaisPorId/{id}")]
        public async Task<JsonResult> RetornaPaisPorId(int id)
        {
            return Json(await this.IPais.GetEntityById(id));
        }

        [HttpPost("/api/EditarPais")]
        public async Task<JsonResult> EditarPais([FromBody] Pais Pais)
        {
            if (String.IsNullOrEmpty(Pais.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPais.Update(Pais)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirPais")]
        public async Task ExcluirPais([FromBody] Pais Pais)
        {
            await Task.FromResult(this.IPais.Delete(Pais));
        }
    }
}
