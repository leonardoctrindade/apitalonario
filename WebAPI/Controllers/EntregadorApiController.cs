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
    public class EntregadorApiController: Controller
    {
        private readonly IEntregador IEntregador;

        public EntregadorApiController(IEntregador IEntregador)
        {
            this.IEntregador = IEntregador;
        }

        [HttpGet("/api/ListaEntregador")]
        public async Task<JsonResult> ListaEntregador()
        {
            try
            {
                return Json(await this.IEntregador.List());
            } 
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os entregadores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEntregador")]
        public async Task<JsonResult> AdicionarEntregador([FromBody] Entregador Entregador)
        {
            try
            {
                if (String.IsNullOrEmpty(Entregador.Nome))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Entregador.Ddd))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Entregador.Telefone))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEntregador.Add(Entregador)));

                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o entregador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaEntregadorPorId/{id}")]
        public async Task<JsonResult> RetornaEntregadorPorId(int id)
        {
            try
            {
                return Json(await this.IEntregador.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o entregador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEntregador")]
        public async Task<JsonResult> EditarEntregador([FromBody] Entregador Entregador)
        {
            try
            {
                if (String.IsNullOrEmpty(Entregador.Nome))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Entregador.Ddd))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Entregador.Telefone))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEntregador.Update(Entregador)));
                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o entregador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEntregador")]
        public async Task<JsonResult> ExcluirEntregador([FromBody] Entregador Entregador)
        {
            try
            {
                return Json(await Task.FromResult(this.IEntregador.Delete(Entregador)));
            } 
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o entregador " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
