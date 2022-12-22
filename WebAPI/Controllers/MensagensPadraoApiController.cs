using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class MensagensPadraoApiController: Controller
    {
        private readonly IMensagensPadrao IMensagensPadrao;

        public MensagensPadraoApiController(IMensagensPadrao IMensagensPadrao)
        {
            this.IMensagensPadrao = IMensagensPadrao;
        }

        [HttpGet("/api/ListaMensagensPadrao")]
        public async Task<JsonResult> ListaMensagensPadrao()
        {
            return Json(await this.IMensagensPadrao.List());
        }

        [HttpPost("/api/AdicionarMensagensPadrao")]
        public async Task<JsonResult> AdicionarMensagensPadrao([FromBody] MensagensPadrao MensagensPadrao)
        {
            if (String.IsNullOrEmpty(MensagensPadrao.StatusDescricao))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(MensagensPadrao.Mensagem))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IMensagensPadrao.Add(MensagensPadrao)));
            return Json(Ok());
        }

        [HttpGet("/api/RetornaMensagensPadraoPorId/{id}")]
        public async Task<JsonResult> RetornaMensagensPadraoPorId(int id)
        {
            return Json(await this.IMensagensPadrao.GetEntityById(id));
        }

        [HttpPost("/api/EditarMensagensPadrao")]
        public async Task<JsonResult> EditarMensagensPadrao([FromBody] MensagensPadrao MensagensPadrao)
        {
            if (String.IsNullOrEmpty(MensagensPadrao.StatusDescricao))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(MensagensPadrao.Mensagem))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IMensagensPadrao.Update(MensagensPadrao)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirMensagensPadrao")]
        public async Task ExcluirMensagensPadrao([FromBody] MensagensPadrao MensagensPadrao)
        {
            await Task.FromResult(this.IMensagensPadrao.Delete(MensagensPadrao));
        }
    }
}
