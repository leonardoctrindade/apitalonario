using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class TurnoApiController: Controller
    {
        private readonly ITurno ITurno;

        public TurnoApiController(ITurno ITurno)
        {
            this.ITurno = ITurno;
        }

        [HttpGet("/api/ListaPaginacaoTurno/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var turnos = await this.ITurno.List();

                var total = Convert.ToDouble(turnos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ITurno.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : turnos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os turnos " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarTurno([FromBody] Turno Turno)
        {
            try
            {
                if (Turno.HoraFinal <= DateTime.MinValue)
                    return BadRequest("Campo de hora final é obrigatório");
                if (Turno.HoraInicial <= DateTime.MinValue)
                    return BadRequest("Campo de hora inicial é obrigatório");
                if (Turno.HoraFinal < Turno.HoraInicial)
                    return BadRequest("Campo de hora final não pode ser menor que o campo de hora inicial");

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
        public async Task<IActionResult> EditarTurno([FromBody] Turno Turno)
        {
            try
            {
                if (Turno.HoraFinal <= DateTime.MinValue)
                    return BadRequest("Campo de hora final é obrigatório");
                if (Turno.HoraInicial <= DateTime.MinValue)
                    return BadRequest("Campo de hora inicial é obrigatório");
                if (Turno.HoraFinal < Turno.HoraInicial)
                    return BadRequest("Campo de hora final não pode ser menor que o campo de hora inicial");

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
