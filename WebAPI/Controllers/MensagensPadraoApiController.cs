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
            try
            {
                return Json(await this.IMensagensPadrao.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as mensagens padrões " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarMensagensPadrao")]
        public async Task<JsonResult> AdicionarMensagensPadrao([FromBody] MensagensPadrao MensagensPadrao)
        {
            try
            {
                if (String.IsNullOrEmpty(MensagensPadrao.StatusDescricao))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(MensagensPadrao.Mensagem))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IMensagensPadrao.Add(MensagensPadrao)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a mensagem padrão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaMensagensPadraoPorId/{id}")]
        public async Task<JsonResult> RetornaMensagensPadraoPorId(int id)
        {
            try
            {
                return Json(await this.IMensagensPadrao.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a mensagem padrão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarMensagensPadrao")]
        public async Task<JsonResult> EditarMensagensPadrao([FromBody] MensagensPadrao MensagensPadrao)
        {
            try
            {
                if (String.IsNullOrEmpty(MensagensPadrao.StatusDescricao))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(MensagensPadrao.Mensagem))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IMensagensPadrao.Update(MensagensPadrao)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar a mensagem padrão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirMensagensPadrao")]
        public async Task<JsonResult> ExcluirMensagensPadrao([FromBody] MensagensPadrao MensagensPadrao)
        {
            try
            {
                return Json(await Task.FromResult(this.IMensagensPadrao.Delete(MensagensPadrao)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a mensagem padrão " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
