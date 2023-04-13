using Data.Entidades;
using Data.Helper;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioApiController : Controller
    {
        private readonly IUsuario iUsuario;
        public UsuarioApiController(IUsuario iUsuario)
        {
            this.iUsuario = iUsuario;
        }


        [HttpGet("/api/ListaUsuario")]
        public async Task<JsonResult> ListaUsuario()
        {

            return Json(await this.iUsuario.List());
        }

        [HttpGet("/api/BuscarUsuario/{matricula}/{senha}")]
        public async Task<JsonResult> BuscarUsuario(int matricula, string senha)
        {
            if (matricula == 0)
                return Json(BadRequest("Informe a Matrícula"));

            if (String.IsNullOrEmpty(senha))
                return Json(BadRequest("Informe a Senha"));

            var senhaCriptografada = Encryptor.MD5Encryption(senha);

            var ret = await this.iUsuario.BuscarUsuario(matricula, senhaCriptografada);

            if (ret == null)
                return Json(NotFound());

            ret.Senha = senha;

            return Json(ret);
        }

      

        [HttpPost("/api/AdicionarUsuario")]
        public async Task<JsonResult> AdicionarUsuario([FromBody] Usuario Usuario)
        {
            if (String.IsNullOrEmpty(Usuario.Nome))
                return Json(BadRequest(ModelState));

            var senhaCriptografada = Encryptor.MD5Encryption(Usuario.Senha);
            Usuario.Senha = senhaCriptografada;

            Json(await Task.FromResult(this.iUsuario.Add(Usuario)));

            return Json(Ok());
        }


        [HttpGet("/api/RetornaUsuarioPorId/{id}")]
        public async Task<JsonResult> RetornaUsuarioPorId(int id)
        {
            return Json(await this.iUsuario.GetEntityById(id));
        }

        [HttpPost("/api/EditarUsuario")]
        public async Task<JsonResult> EditarUsuario([FromBody] Usuario Usuario)
        {
            if (String.IsNullOrEmpty(Usuario.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.iUsuario.Update(Usuario)));
            return Json(Ok());

        }

      
    }
}