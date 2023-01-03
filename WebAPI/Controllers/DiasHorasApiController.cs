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
    public class DiasHorasApiController : Controller
    {
        private readonly IDiasHoras IDiasHoras;

        public DiasHorasApiController(IDiasHoras IDiasHoras)
        {
            this.IDiasHoras = IDiasHoras;
        }

        [HttpGet("/api/ListaDiasHoras")]
        public async Task<JsonResult> ListaDiasHoras()
        {
            try
            {
                return Json(await this.IDiasHoras.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os dias/horas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarDiasHoras")]
        public async Task<JsonResult> AdicionarDiasHoras([FromBody] DiasHoras DiasHoras)
        {
            try
            {
                if (DiasHoras.CodigoDia <= 0 || DiasHoras.Sequencia <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IDiasHoras.Add(DiasHoras)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o dia/hora " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaDiasHorasPorId/{id}")]
        public async Task<JsonResult> RetornaDiasHorasPorId(int id)
        {
            try
            {
                return Json(await this.IDiasHoras.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o dia/hora " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarDiasHoras")]
        public async Task<JsonResult> EditarDiasHoras([FromBody] DiasHoras DiasHoras)
        {
            try
            {
                if (DiasHoras.CodigoDia <= 0 || DiasHoras.Sequencia <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IDiasHoras.Update(DiasHoras)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o dia/hora" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirDiasHoras")]
        public async Task<JsonResult> ExcluirDiasHoras([FromBody] DiasHoras DiasHoras)
        {
            try
            {
                Json(await Task.FromResult(this.IDiasHoras.Delete(DiasHoras)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o dia/hora " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
