using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class MensagensPadraoApiController: Controller
    {
        private readonly IMensagensPadrao IMensagensPadrao;

        public MensagensPadraoApiController(IMensagensPadrao IMensagensPadrao)
        {
            this.IMensagensPadrao = IMensagensPadrao;
        }

        [HttpGet("/api/ListaPaginacaoMensagensPadrao/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var mensagens = await this.IMensagensPadrao.List();

                var total = Convert.ToDouble(mensagens.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IMensagensPadrao.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : mensagens);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os mensagens padrões " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarMensagensPadrao([FromBody] MensagensPadrao MensagensPadrao)
        {
            try
            {
                if (String.IsNullOrEmpty(MensagensPadrao.StatusDescricao.Trim()))
                    return BadRequest("Campo de status descrição é obrigatório");
                if (String.IsNullOrEmpty(MensagensPadrao.Mensagem))
                    return BadRequest("Campo de mensagem é obrigatório");

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
        public async Task<IActionResult> EditarMensagensPadrao([FromBody] MensagensPadrao MensagensPadrao)
        {
            try
            {
                if (String.IsNullOrEmpty(MensagensPadrao.StatusDescricao.Trim()))
                    return BadRequest("Campo de status descrição é obrigatório");
                if (String.IsNullOrEmpty(MensagensPadrao.Mensagem))
                    return BadRequest("Campo de mensagem é obrigatório");

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
                Json(await Task.FromResult(this.IMensagensPadrao.Delete(MensagensPadrao)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a mensagem padrão " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
