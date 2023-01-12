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
            try
            {
                return Json(await this.ITurno.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os turnos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTurno")]
        public async Task<JsonResult> AdicionarTurno([FromBody] Turno Turno)
        {
            try
            {
                if (Turno.HoraFinal <= DateTime.MinValue)
                    return Json(BadRequest(ModelState));
                if (Turno.HoraInicial <= DateTime.MinValue)
                    return Json(BadRequest(ModelState));
                if (Turno.HoraFinal < Turno.HoraInicial)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITurno.Add(Turno)));

                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o turno " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTurnoPorId/{id}")]
        public async Task<JsonResult> RetornaTurnoPorId(int id)
        {
            try
            {
                return Json(await this.ITurno.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o turno " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTurno")]
        public async Task<JsonResult> EditarTurno([FromBody] Turno Turno)
        {
            try
            {
                if (Turno.HoraFinal < DateTime.MinValue)
                    return Json(BadRequest(ModelState));
                if (Turno.HoraInicial < DateTime.MinValue)
                    return Json(BadRequest(ModelState));
                if (Turno.HoraFinal < Turno.HoraInicial)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITurno.Update(Turno)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o turno " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTurno")]
        public async Task<JsonResult> ExcluirTurno([FromBody] Turno Turno)
        {
            try
            {
                Json(await Task.FromResult(this.ITurno.Delete(Turno)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o turno " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
