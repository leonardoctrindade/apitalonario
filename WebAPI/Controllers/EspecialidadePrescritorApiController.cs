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
    public class EspecialidadePrescritorApiController : Controller
    {
        private readonly IEspecialidadePrescritor IEspecialidadePrescritor;
        
        public EspecialidadePrescritorApiController(IEspecialidadePrescritor especialidadePrescritor)
        {
            this.IEspecialidadePrescritor = especialidadePrescritor;
        }

        [HttpGet("/api/ListaEspecialidadePrescritor")]
        public async Task<JsonResult> ListaEspecialidadePrescritor()
        {
            try
            {
                return Json(await this.IEspecialidadePrescritor.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as especialidades do prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEspecialidadePrescritor")]
        public async Task<JsonResult> AdicionarEspecialidadePrescritor([FromBody] EspecialidadePrescritor especialidadePrescritor)
        {
            try
            {
                if (especialidadePrescritor.EspecialidadeId == 0 || especialidadePrescritor.PrescritorId == 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEspecialidadePrescritor.Add(especialidadePrescritor)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a especialidade do prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarEspecialidadePrescritorPorId/{id}")]
        public async Task<JsonResult> RetornarEspecialidadePrescritorPorId(int id)
        {
            try
            {
                return Json(await this.IEspecialidadePrescritor.GetEspecialidadePrescritor(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a especialidade do prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEspecialidadePrescritor")]
        public async Task<JsonResult> ExcluirEspecialidadePrescritor([FromBody] EspecialidadePrescritor especialidadePrescritor)
        {
            try
            {
                return Json(await Task.FromResult(this.IEspecialidadePrescritor.Delete(especialidadePrescritor)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a especialidade do prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
