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
            return Json(await this.IEspecialidadePrescritor.List()); 
        }
        [HttpPost("/api/AdicionarEspecialidadePrescritor")]
        public async Task<JsonResult> AdicionarEspecialidadePrescritor([FromBody] EspecialidadePrescritor especialidadePrescritor)
        {
            if (especialidadePrescritor.IdEspecialidade == 0 || especialidadePrescritor.IdPrescritor == 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEspecialidadePrescritor.Add(especialidadePrescritor)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarEspecialidadePrescritorPorId/{id}")]
        public async Task<JsonResult> RetornarEspecialidadePrescritorPorId(int id)
        {
            return Json(await this.IEspecialidadePrescritor.GetEntityById(id));
        }
        [HttpPost("/api/ExcluirEspecialidadePrescritor")]
        public async Task ExcluirEspecialidadePrescritor([FromBody] EspecialidadePrescritor especialidadePrescritor)
        {
            await Task.FromResult(this.IEspecialidadePrescritor.Delete(especialidadePrescritor));
        }
    }
}
