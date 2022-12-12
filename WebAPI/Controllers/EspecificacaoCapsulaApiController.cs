using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Controllers
{
    public class EspecificacaoCapsulaApiController: Controller
    {
        private readonly IEspecificacaoCapsula IEspecificacaoCapsula;

        public EspecificacaoCapsulaApiController(IEspecificacaoCapsula IEspecificacaoCapsula)
        {
            this.IEspecificacaoCapsula = IEspecificacaoCapsula;
        }

        [HttpGet("/api/ListaEspecificacaoCapsula")]
        public async Task<JsonResult> ListaEspecificacaoCapsula()
        {
            return Json(await this.IEspecificacaoCapsula.List());
        }

        [HttpPost("/api/AdicionarEspecificacaoCapsula")]
        public async Task<JsonResult> AdicionarEspecificacaoCapsula([FromBody] EspecificacaoCapsula EspecificacaoCapsula)
        {
            if (String.IsNullOrEmpty(EspecificacaoCapsula.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEspecificacaoCapsula.Add(EspecificacaoCapsula)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaEspecificacaoCapsulaPorId/{id}")]
        public async Task<JsonResult> RetornaEspecificacaoCapsulaPorId(int id)
        {
            return Json(await this.IEspecificacaoCapsula.GetEntityById(id));
        }

        [HttpPost("/api/EditarEspecificacaoCapsula")]
        public async Task<JsonResult> EditarEspecificacaoCapsula([FromBody] EspecificacaoCapsula EspecificacaoCapsula)
        {
            if (String.IsNullOrEmpty(EspecificacaoCapsula.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEspecificacaoCapsula.Update(EspecificacaoCapsula)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirEspecificacaoCapsula")]
        public async Task ExcluirEspecificacaoCapsula([FromBody] EspecificacaoCapsula EspecificacaoCapsula)
        {
            await Task.FromResult(this.IEspecificacaoCapsula.Delete(EspecificacaoCapsula));
        }
    }
}
