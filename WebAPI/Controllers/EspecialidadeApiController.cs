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
    public class EspecialidadeApiController : Controller
    {
        private readonly IEspecialidade IEspecialidade;

        public EspecialidadeApiController(IEspecialidade iEspecialidade)
        {
            IEspecialidade = iEspecialidade;
        }

        [HttpGet("/api/ListaEspecialidade")]
        public async Task<JsonResult> ListaEspecialidade()
        {
            try
            {
                return Json(await this.IEspecialidade.List());
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
        }

        [HttpPost("/api/AdicionarEspecialidade")]
        public async Task<JsonResult> AdicionarEspecialidade([FromBody] Especialidade especialidade)
        {
            if (string.IsNullOrEmpty(especialidade.Descricao))
                return Json(BadRequest(ModelState));

            try
            {
                Json(await Task.FromResult(this.IEspecialidade.Add(especialidade)));
                return Json(Ok());
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
        }

        [HttpGet("/api/RetornarEspecialidadePorId/{id}")]
        public async Task<JsonResult> RetornarEspecialidadePorId(int id)
        {
            try
            {
                return Json(await this.IEspecialidade.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a especialidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEspecialidade")]
        public async Task<JsonResult> EditarEspecialidade([FromBody] Especialidade especialidade)
        {
            if (string.IsNullOrEmpty(especialidade.Descricao))
                return Json(BadRequest(ModelState));

            try
            {
                Json(await Task.FromResult(this.IEspecialidade.Update(especialidade)));
                return Json(Ok());
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
        }

        [HttpPost("/api/ExcluirEspecialidade")]
        public async Task<JsonResult> ExcluirEspecialidade([FromBody] Especialidade especialidade)
        {
            try
            {
                Json(await Task.FromResult(this.IEspecialidade.Delete(especialidade)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a especialidade " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
