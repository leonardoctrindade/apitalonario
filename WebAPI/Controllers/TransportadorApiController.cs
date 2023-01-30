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
    public class TransportadorApiController : Controller
    {
        private readonly ITransportador ITransportador;
        
        public TransportadorApiController(ITransportador transportador)
        {
            this.ITransportador = transportador;
        }

        [HttpGet("/api/ListaPaginacaoTransportador/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var transportadores = await this.ITransportador.List();

                var total = Convert.ToDouble(transportadores.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ITransportador.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : transportadores);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os transportadores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaTransportador")]
        public async Task<JsonResult> ListaTransportador()
        {
            try
            {
                return Json(await this.ITransportador.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os transportadores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTransportador")]
        public async Task<IActionResult> AdicionarTransportador([FromBody] Transportador transportador)
        {
            try
            {
                if (string.IsNullOrEmpty(transportador.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");
                if (string.IsNullOrEmpty(transportador.CpfCnpj.Trim()))
                    return BadRequest("Campo de cpf/cnpj é obrigatório");

                Json(await Task.FromResult(this.ITransportador.Add(transportador)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o transportador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTransportadorPorId/{id}")]
        public async Task<JsonResult> RetornarTransportadorPorId(int id)
        {
            try
            {
                if (id <= 0)
                    return Json(BadRequest(ModelState));

                return Json(await this.ITransportador.GetTransportador(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o transportador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTransportador")]
        public async Task<IActionResult> EditarTransportador([FromBody] Transportador transportador)
        {
            try
            {
                if (string.IsNullOrEmpty(transportador.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");
                if (string.IsNullOrEmpty(transportador.CpfCnpj.Trim()))
                    return BadRequest("Campo de cpf/cnpj é obrigatório");

                Json(await Task.FromResult(this.ITransportador.Update(transportador)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o transportador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTransportador")]
        public async Task<JsonResult> ExcluirTransportador([FromBody] Transportador transportador)
        {
            try
            {
                Json(await Task.FromResult(this.ITransportador.Delete(transportador)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o transportador " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
