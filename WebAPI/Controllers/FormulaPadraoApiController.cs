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
    public class FormulaPadraoApiController: Controller
    {
        private readonly IFormulaPadrao IFormulaPadrao;

        public FormulaPadraoApiController(IFormulaPadrao IFormulaPadrao)
        {
            this.IFormulaPadrao = IFormulaPadrao;
        }

        [HttpGet("/api/ListaFormulaPadrao")]
        public async Task<JsonResult> ListaFormulaPadrao()
        {
            return Json(await this.IFormulaPadrao.List());
        }

        [HttpPost("/api/AdicionarFormulaPadrao")]
        public async Task<JsonResult> AdicionarFormulaPadrao([FromBody] FormulaPadrao FormulaPadrao)
        {
            if (String.IsNullOrEmpty(FormulaPadrao.Descricao))
                return Json(BadRequest(ModelState));
            if (FormulaPadrao.IdFormaFarmaceutica <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFormulaPadrao.Add(FormulaPadrao)));
            return Json(Ok());
        }

        [HttpGet("/api/RetornaFormulaPadraoPorId/{id}")]
        public async Task<JsonResult> RetornaFormulaPadraoPorId(int id)
        {
            return Json(await this.IFormulaPadrao.GetEntityById(id));
        }

        [HttpPost("/api/EditarFormulaPadrao")]
        public async Task<JsonResult> EditarFormulaPadrao([FromBody] FormulaPadrao FormulaPadrao)
        {
            if (String.IsNullOrEmpty(FormulaPadrao.Descricao))
                return Json(BadRequest(ModelState));
            if (FormulaPadrao.IdFormaFarmaceutica <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFormulaPadrao.Update(FormulaPadrao)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirFormulaPadrao")]
        public async Task ExcluirFormulaPadrao([FromBody] FormulaPadrao FormulaPadrao)
        {
            await Task.FromResult(this.IFormulaPadrao.Delete(FormulaPadrao));
        }
    }
}
