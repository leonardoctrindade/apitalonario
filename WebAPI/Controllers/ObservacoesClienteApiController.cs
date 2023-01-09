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
    public class ObservacoesClienteApiController : Controller
    {
        private readonly IObservacoesCliente IObservacoesCliente;

        public ObservacoesClienteApiController(IObservacoesCliente IObservacoesCliente)
        {
            this.IObservacoesCliente = IObservacoesCliente;
        }

        [HttpGet("/api/ListaObservacoesCliente")]
        public async Task<JsonResult> ListaObservacoesCliente()
        {
            try
            {
                return Json(await this.IObservacoesCliente.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as observacoes do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarObservacoesCliente")]
        public async Task<JsonResult> AdicionarObservacoesCliente([FromBody] ObservacoesCliente ObservacoesCliente)
        {
            try
            {
                if (ObservacoesCliente.ClienteId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IObservacoesCliente.Add(ObservacoesCliente)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a observacao do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaObservacoesClientePorId/{id}")]
        public async Task<JsonResult> RetornaObservacoesClientePorId(int id)
        {
            try
            {
                return Json(await this.IObservacoesCliente.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a observacao do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarObservacoesCliente")]
        public async Task<JsonResult> EditarObservacoesCliente([FromBody] ObservacoesCliente ObservacoesCliente)
        {
            try
            {
                if (ObservacoesCliente.ClienteId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IObservacoesCliente.Update(ObservacoesCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a observacao do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirObservacoesCliente")]
        public async Task<JsonResult> ExcluirObservacoesCliente([FromBody] ObservacoesCliente ObservacoesCliente)
        {
            try
            {
                Json(await Task.FromResult(this.IObservacoesCliente.Delete(ObservacoesCliente)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a observacao do cliente " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
