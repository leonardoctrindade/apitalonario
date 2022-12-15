using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class GrupoUsuarioApiController : Controller
    {
        private readonly IGrupoUsuario IGrupoUsuario;

        public GrupoUsuarioApiController(IGrupoUsuario IGrupoUsuario)
        {
            this.IGrupoUsuario = IGrupoUsuario;
        }

        [HttpGet("/api/ListaGrupoUsuario")]
        public async Task<JsonResult> ListaGrupoUsuario()
        {
            return Json(await this.IGrupoUsuario.List());
        }

        [HttpPost("/api/AdicionarGrupoUsuario")]
        public async Task<JsonResult> AdicionarGrupoUsuario([FromBody] GrupoUsuario GrupoUsuario)
        {
            if (String.IsNullOrEmpty(GrupoUsuario.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IGrupoUsuario.Add(GrupoUsuario)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaGrupoUsuarioPorId/{id}")]
        public async Task<JsonResult> RetornaGrupoUsuarioPorId(int id)
        {
            return Json(await this.IGrupoUsuario.GetEntityById(id));
        }

        [HttpPost("/api/EditarGrupoUsuario")]
        public async Task<JsonResult> EditarGrupoUsuario([FromBody] GrupoUsuario GrupoUsuario)
        {
            if (String.IsNullOrEmpty(GrupoUsuario.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IGrupoUsuario.Update(GrupoUsuario)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirGrupoUsuario")]
        public async Task ExcluirGrupoUsuario([FromBody] GrupoUsuario GrupoUsuario)
        {
            await Task.FromResult(this.IGrupoUsuario.Delete(GrupoUsuario));
        }
    }
}
