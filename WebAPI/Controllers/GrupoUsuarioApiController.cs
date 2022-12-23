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
            try
            {
                return Json(await this.IGrupoUsuario.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os grupos de usuario " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarGrupoUsuario")]
        public async Task<JsonResult> AdicionarGrupoUsuario([FromBody] GrupoUsuario GrupoUsuario)
        {
            try 
            {
                if (String.IsNullOrEmpty(GrupoUsuario.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IGrupoUsuario.Add(GrupoUsuario)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o grupo de usuario " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaGrupoUsuarioPorId/{id}")]
        public async Task<JsonResult> RetornaGrupoUsuarioPorId(int id)
        {
            try
            {
                return Json(await this.IGrupoUsuario.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o grupo de usuario " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarGrupoUsuario")]
        public async Task<JsonResult> EditarGrupoUsuario([FromBody] GrupoUsuario GrupoUsuario)
        {
            try
            {
                if (String.IsNullOrEmpty(GrupoUsuario.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IGrupoUsuario.Update(GrupoUsuario)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o grupo de usuario " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirGrupoUsuario")]
        public async Task<JsonResult> ExcluirGrupoUsuario([FromBody] GrupoUsuario GrupoUsuario)
        {
            try
            {
                return Json(await Task.FromResult(this.IGrupoUsuario.Delete(GrupoUsuario)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o grupo de usuario " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
