using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class TurnoApiController: Controller
    {
        private readonly ITurno ITurno;

        public TurnoApiController(ITurno ITurno)
        {
            this.ITurno = ITurno;
        }

        [HttpGet("/api/ListaTurno")]
        public async Task<JsonResult> ListaTurno()
        {
            return Json(await this.ITurno.List());
        }

        [HttpPost("/api/AdicionarTurno")]
        public async Task<JsonResult> AdicionarTurno([FromBody] Turno Turno)
        {
            if (String.IsNullOrEmpty(Turno.HoraFinal))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Turno.HoraInicial))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITurno.Add(Turno)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaTurnoPorId/{id}")]
        public async Task<JsonResult> RetornaTurnoPorId(int id)
        {
            return Json(await this.ITurno.GetEntityById(id));
        }

        [HttpPost("/api/EditarTurno")]
        public async Task<JsonResult> EditarTurno([FromBody] Turno Turno)
        {
            if(String.IsNullOrEmpty(Turno.HoraFinal))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Turno.HoraInicial))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITurno.Update(Turno)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirTurno")]
        public async Task ExcluirTurno([FromBody] Turno Turno)
        {
            await Task.FromResult(this.ITurno.Delete(Turno));
        }
    }
}
