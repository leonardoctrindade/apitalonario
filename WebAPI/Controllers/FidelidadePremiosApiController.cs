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
    public class FidelidadePremiosApiController: Controller
    {
        private readonly IFidelidadePremios IFidelidadePremios;

        public FidelidadePremiosApiController(IFidelidadePremios IFidelidadePremios)
        {
            this.IFidelidadePremios = IFidelidadePremios;
        }

        [HttpGet("/api/ListaFidelidadePremios")]
        public async Task<JsonResult> ListaFidelidadePremios()
        {
            try
            {
                return Json(await this.IFidelidadePremios.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os premios de fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFidelidadePremios")]
        public async Task<JsonResult> AdicionarFidelidadePremios([FromBody] FidelidadePremios FidelidadePremios)
        {
            try
            {
                if (FidelidadePremios.IdFidelidade == 0 || FidelidadePremios.IdGrupo == 0 || FidelidadePremios.IdProduto == 0 || FidelidadePremios.Pontos < 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFidelidadePremios.Add(FidelidadePremios)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o premio de fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFidelidadePremiosPorId/{id}")]
        public async Task<JsonResult> RetornaFidelidadePremiosPorId(int id)
        {
            try
            {
                return Json(await this.IFidelidadePremios.GetFidelidadePremios(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o premio de fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFidelidadePremios")]
        public async Task<JsonResult> EditarFidelidadePremios([FromBody] FidelidadePremios FidelidadePremios)
        {
            try
            {
                if (FidelidadePremios.IdFidelidade == 0 || FidelidadePremios.IdGrupo == 0 || FidelidadePremios.IdProduto == 0 || FidelidadePremios.Pontos < 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFidelidadePremios.Update(FidelidadePremios)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o premio de fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFidelidadePremios")]
        public async Task<JsonResult> ExcluirFidelidadePremios([FromBody] FidelidadePremios FidelidadePremios)
        {
            try
            {
                return Json(await Task.FromResult(this.IFidelidadePremios.Delete(FidelidadePremios)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o premio de fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
