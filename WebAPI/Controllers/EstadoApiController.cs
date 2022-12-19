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
    public class EstadoApiController : Controller
    {
        private readonly IEstado IEstado;

        public EstadoApiController(IEstado IEstado)
        {
            this.IEstado = IEstado;
        }

        [HttpGet("/api/ListaEstado")]
        public async Task<JsonResult> ListaEstado()
        {
            return Json(await this.IEstado.List());
        }

        [HttpPost("/api/AdicionarEstado")]
        public async Task<JsonResult> AdicionarEstado([FromBody] Estado Estado)
        {
            if (String.IsNullOrEmpty(Estado.Nome))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Estado.Sigla) || Estado.Sigla.Count() != 2)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEstado.Add(Estado)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaEstadoPorId/{id}")]
        public async Task<JsonResult> RetornaEstadoPorId(int id)
        {
            return Json(await this.IEstado.GetEntityById(id));
        }

        [HttpPost("/api/EditarEstado")]
        public async Task<JsonResult> EditarEstado([FromBody] Estado Estado)
        {
            if (String.IsNullOrEmpty(Estado.Nome))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Estado.Sigla) || Estado.Sigla.Count() != 2)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEstado.Update(Estado)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirEstado")]
        public async Task ExcluirEstado([FromBody] Estado Estado)
        {
            await Task.FromResult(this.IEstado.Delete(Estado));
        }
    }
}
