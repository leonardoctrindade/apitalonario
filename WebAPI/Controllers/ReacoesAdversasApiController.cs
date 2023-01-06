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
    public class ReacoesAdversasApiController : Controller
    {
        private readonly IReacoesAdversas IReacoesAdversas;

        public ReacoesAdversasApiController(IReacoesAdversas IReacoesAdversas)
        {
            this.IReacoesAdversas = IReacoesAdversas;
        }

        [HttpGet("/api/ListaReacoesAdversas")]
        public async Task<JsonResult> ListaReacoesAdversas()
        {
            try
            {
                return Json(await this.IReacoesAdversas.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as reacoes adversas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarReacoesAdversas")]
        public async Task<JsonResult> AdicionarReacoesAdversas([FromBody] ReacoesAdversas ReacoesAdversas)
        {
            try
            {
                if (!ReacoesAdversas.Data.HasValue || string.IsNullOrEmpty(ReacoesAdversas.Medicamento) || string.IsNullOrEmpty(ReacoesAdversas.Dose) || ReacoesAdversas.ClienteId <= 0 )
                    return Json(BadRequest(ModelState));
                    
                Json(await Task.FromResult(this.IReacoesAdversas.Add(ReacoesAdversas)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a Reacão Adversa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaReacoesAdversasPorId/{id}")]
        public async Task<JsonResult> RetornaReacoesAdversasPorId(int id)
        {
            try
            {
                return Json(await this.IReacoesAdversas.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a Reação adversa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarReacoesAdversas")]
        public async Task<JsonResult> EditarReacoesAdversas([FromBody] ReacoesAdversas ReacoesAdversas)
        {
            try
            {
                if (!ReacoesAdversas.Data.HasValue || string.IsNullOrEmpty(ReacoesAdversas.Medicamento) || string.IsNullOrEmpty(ReacoesAdversas.Dose) || ReacoesAdversas.ClienteId <= 0 )
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IReacoesAdversas.Update(ReacoesAdversas)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar as reacoes adversas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirReacoesAdversas")]
        public async Task<JsonResult> ExcluirReacoesAdversas([FromBody] ReacoesAdversas ReacoesAdversas)
        {
            try
            {
                Json(await Task.FromResult(this.IReacoesAdversas.Delete(ReacoesAdversas)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a reacao adversas " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
