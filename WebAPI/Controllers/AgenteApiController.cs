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
    public class AgenteApiController : Controller
    {
        private readonly IAgente iAgente;
        public AgenteApiController(IAgente iAgente)
        {
            this.iAgente = iAgente;
        }


        [HttpGet("/api/ListaAgente")]
        public async Task<JsonResult> ListaAgente()
        {

            return Json(await this.iAgente.List());
        }

        [HttpGet("/api/BuscarAgente/{matricula}/{senha}")]
        public async Task<JsonResult> BuscarAgente(int matricula, string senha)
        {
            if (matricula == 0)
                return Json(BadRequest("Informe a Matrícula"));

            if (String.IsNullOrEmpty(senha))
                return Json(BadRequest("Informe a Senha"));

            var senhaCriptografada = Encryptor.MD5Encryption(senha);

            var ret = await this.iAgente.BuscarAgente(matricula, senhaCriptografada);

            if (ret == null)
                return Json(NotFound());

            return Json(ret);
        }

        [HttpGet("/api/MudarSenhaAgente/{matricula}/{novaSenha}/{assinaturaDigital}")]
        public async Task<JsonResult> MudarSenhaAgente(int matricula, string novaSenha, string assinaturaDigital)
        {
            if (matricula == 0)
                return Json(BadRequest("Informe a Matrícula"));

            if (String.IsNullOrEmpty(novaSenha))
                return Json(BadRequest("Informe a Senha"));

            var senhaCriptografada = Encryptor.MD5Encryption(novaSenha);

            var ret = await this.iAgente.BuscarAgente(matricula);
            if (ret == null)
                return Json(NotFound());

            Json(await Task.FromResult(this.iAgente.MudarSenhaAgente(matricula, senhaCriptografada, assinaturaDigital)));

            return Json(Ok());
        }


        [HttpPost("/api/AdicionarAgente")]
        public async Task<JsonResult> AdicionarAgente([FromBody] Agente Agente)
        {
            if (String.IsNullOrEmpty(Agente.Nome))
                return Json(BadRequest(ModelState));

            var senhaCriptografada = Encryptor.MD5Encryption(Agente.Senha);
            Agente.Senha = senhaCriptografada;

            Json(await Task.FromResult(this.iAgente.Add(Agente)));

            return Json(Ok());
        }


        [HttpGet("/api/RetornaAgentePorId/{id}")]
        public async Task<JsonResult> RetornaAgentePorId(int id)
        {
            return Json(await this.iAgente.GetEntityById(id));
        }

        [HttpPost("/api/EditarAgente")]
        public async Task<JsonResult> EditarAgente([FromBody] Agente Agente)
        {
            if (String.IsNullOrEmpty(Agente.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.iAgente.Update(Agente)));
            return Json(Ok());

        }

        [HttpPost("/api/ExcluirBpm")]
        public async Task ExcluirBpm([FromBody] Agente Agente)
        {
            await Task.FromResult(this.iAgente.Delete(Agente));
        }

    }
}