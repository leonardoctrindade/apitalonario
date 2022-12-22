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
    public class NcmEstadoApiController: Controller
    {
        private readonly INcmEstado INcmEstado;

        public NcmEstadoApiController(INcmEstado INcmEstado)
        {
            this.INcmEstado = INcmEstado;
        }

        [HttpGet("/api/ListaNcmEstado")]
        public async Task<JsonResult> ListaNcmEstado()
        {
            return Json(await this.INcmEstado.List());
        }

        [HttpPost("/api/AdicionarNcmEstado")]
        public async Task<JsonResult> AdicionarNcmEstado([FromBody] NcmEstado NcmEstado)
        {
            if (NcmEstado.IdEstadoOrigem <= 0 || NcmEstado.IdEstadoDestino <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.INcmEstado.Add(NcmEstado)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaNcmEstadoPorId/{id}")]
        public async Task<JsonResult> RetornaNcmEstadoPorId(int id)
        {
            return Json(await this.INcmEstado.GetEntityById(id));
        }

        [HttpPost("/api/EditarNcmEstado")]
        public async Task<JsonResult> EditarNcmEstado([FromBody] NcmEstado NcmEstado)
        {
            if (NcmEstado.IdEstadoOrigem <= 0 || NcmEstado.IdEstadoDestino <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.INcmEstado.Update(NcmEstado)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirNcmEstado")]
        public async Task ExcluirNcmEstado([FromBody] NcmEstado NcmEstado)
        {
            await Task.FromResult(this.INcmEstado.Delete(NcmEstado));
        }
    }
}
