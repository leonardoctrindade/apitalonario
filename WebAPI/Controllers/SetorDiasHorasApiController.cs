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
    public class SetorDiasHorasApiController : Controller
    {
        private readonly ISetorDiasHoras ISetorDiasHoras;

        public SetorDiasHorasApiController(ISetorDiasHoras ISetorDiasHoras)
        {
            this.ISetorDiasHoras = ISetorDiasHoras;
        }

        [HttpGet("/api/ListaSetorDiasHoras")]
        public async Task<JsonResult> ListaSetorDiasHoras()
        {
            try
            {
                return Json(await this.ISetorDiasHoras.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os SetoresDiasHoras " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarSetorDiasHoras")]
        public async Task<JsonResult> AdicionarSetorDiasHoras([FromBody] SetorDiasHoras SetorDiasHoras)
        {
            try
            {
                if (SetorDiasHoras.DiasHorasId <= 0 || SetorDiasHoras.SetorId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ISetorDiasHoras.Add(SetorDiasHoras)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o SetorDiasHoras " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaSetorDiasHorasPorId/{id}")]
        public async Task<JsonResult> RetornaSetorDiasHorasPorId(int id)
        {
            try
            {
                return Json(await this.ISetorDiasHoras.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o SetorDiasHoras " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarSetorDiasHoras")]
        public async Task<JsonResult> EditarSetorDiasHoras([FromBody] SetorDiasHoras SetorDiasHoras)
        {
            try
            {
                if (SetorDiasHoras.DiasHorasId <= 0 || SetorDiasHoras.SetorId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ISetorDiasHoras.Update(SetorDiasHoras)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o SetorDiasHoras " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirSetorDiasHoras")]
        public async Task<JsonResult> ExcluirSetorDiasHoras([FromBody] SetorDiasHoras SetorDiasHoras)
        {
            try
            {
                return Json(await Task.FromResult(this.ISetorDiasHoras.Delete(SetorDiasHoras)));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o SetorDiasHoras " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
