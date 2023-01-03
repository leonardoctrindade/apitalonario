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
            try
            {
                return Json(await this.IUsuario.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os usuarios " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarUsuario")]
        public async Task<JsonResult> AdicionarUsuario([FromBody] Usuario Usuario)
        {
            try
            {
                if (String.IsNullOrEmpty(Usuario.Nome))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Usuario.NomeAbreviado))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Usuario.Senha))
                    return Json(BadRequest(ModelState));
                if (Usuario.GrupoUsuarioId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IUsuario.Add(Usuario)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o usuario " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaUsuarioPorId/{id}")]
        public async Task<JsonResult> RetornaUsuarioPorId(int id)
        {
            try
            {
                return Json(await this.IUsuario.GetUsuario(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o usuario " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarUsuario")]
        public async Task<JsonResult> EditarUsuario([FromBody] Usuario Usuario)
        {
            try
            {
                if (String.IsNullOrEmpty(Usuario.Nome))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Usuario.NomeAbreviado))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Usuario.Senha))
                    return Json(BadRequest(ModelState));
                if (Usuario.GrupoUsuarioId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IUsuario.Update(Usuario)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o usuario " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirUsuario")]
        public async Task<JsonResult> ExcluirUsuario([FromBody] Usuario Usuario)
        {
            try
            {
                Json(await Task.FromResult(this.IUsuario.Delete(Usuario)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o usuario " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
