using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class UsuarioApiController : Controller
    {
        private readonly IUsuario IUsuario;

        public UsuarioApiController(IUsuario IUsuario)
        {
            this.IUsuario = IUsuario;
        }

        [HttpGet("/api/ListaUsuario")]
        public async Task<JsonResult> ListaUsuario()
        {
            return Json(await this.IUsuario.List());
        }

        [HttpPost("/api/AdicionarUsuario")]
        public async Task<JsonResult> AdicionarUsuario([FromBody] Usuario Usuario)
        {
            if (String.IsNullOrEmpty(Usuario.Nome))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Usuario.NomeAbreviado))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Usuario.Senha))
                return Json(BadRequest(ModelState));
            if (Usuario.IdGrupoUsuario <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IUsuario.Add(Usuario)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaUsuarioPorId/{id}")]
        public async Task<JsonResult> RetornaUsuarioPorId(int id)
        {
            return Json(await this.IUsuario.GetEntityById(id));
        }

        [HttpPost("/api/EditarUsuario")]
        public async Task<JsonResult> EditarUsuario([FromBody] Usuario Usuario)
        {
            if (String.IsNullOrEmpty(Usuario.Nome))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Usuario.NomeAbreviado))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Usuario.Senha))
                return Json(BadRequest(ModelState));
            if (Usuario.IdGrupoUsuario <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IUsuario.Update(Usuario)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirUsuario")]
        public async Task ExcluirUsuario([FromBody] Usuario Usuario)
        {
            await Task.FromResult(this.IUsuario.Delete(Usuario));
        }
    }
}
