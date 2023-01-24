using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class UsuarioApiController : Controller
    {
        private readonly IUsuario IUsuario;

        public UsuarioApiController(IUsuario IUsuario)
        {
            this.IUsuario = IUsuario;
        }

        [HttpGet("/api/ListaPaginacaoUsuario/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var usuarios = await this.IUsuario.List();

                var total = Convert.ToDouble(usuarios.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IUsuario.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : usuarios);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os usuarios " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarUsuario([FromBody] Usuario Usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(Usuario.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");
                if (string.IsNullOrEmpty(Usuario.NomeAbreviado.Trim()))
                    return BadRequest("Campo de nome abreviado é obrigatório");
                if (string.IsNullOrEmpty(Usuario.Senha.Trim()))
                    return BadRequest("Campo de senha é obrigatório");
                if (Usuario.GrupoUsuarioId <= 0)
                    return BadRequest("Campo de grupo de usuario é obrigatório");

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
        public async Task<IActionResult> EditarUsuario([FromBody] Usuario Usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(Usuario.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");
                if (string.IsNullOrEmpty(Usuario.NomeAbreviado.Trim()))
                    return BadRequest("Campo de nome abreviado é obrigatório");
                if (string.IsNullOrEmpty(Usuario.Senha.Trim()))
                    return BadRequest("Campo de senha é obrigatório");
                if (Usuario.GrupoUsuarioId <= 0)
                    return BadRequest("Campo de grupo de usuario é obrigatório");

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
