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
    public class QuantidadeXValorHomeopatiaApiController : Controller
    {
        private readonly IQuantidadeXValorHomeopatia IQuantidadeXValorHomeopatia;

        public QuantidadeXValorHomeopatiaApiController(IQuantidadeXValorHomeopatia IQuantidadeXValorHomeopatia)
        {
            this.IQuantidadeXValorHomeopatia = IQuantidadeXValorHomeopatia;
        }

        [HttpGet("/api/ListaQuantidadeXValorHomeopatia")]
        public async Task<JsonResult> ListaQuantidadeXValorHomeopatia()
        {
            try
            {
                return Json(await this.IQuantidadeXValorHomeopatia.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as quantidades X valor homeopatia" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarQuantidadeXValorHomeopatia")]
        public async Task<JsonResult> AdicionarQuantidadeXValorHomeopatia([FromBody] QuantidadeXValorHomeopatia QuantidadeXValorHomeopatia)
        {
            try
            {
                if (QuantidadeXValorHomeopatia.QuantidadeInicial < 0 ||
                    QuantidadeXValorHomeopatia.QuantidadeFinal <= 0 ||
                    QuantidadeXValorHomeopatia.ValorVenda <= 0 ||
                    QuantidadeXValorHomeopatia.ValorAdicional < 0 ||
                    QuantidadeXValorHomeopatia.IntervaloDinamizacaoId <= 0 ||
                    QuantidadeXValorHomeopatia.QuantidadeFinal < QuantidadeXValorHomeopatia.QuantidadeInicial
                    )
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IQuantidadeXValorHomeopatia.Add(QuantidadeXValorHomeopatia)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a quantidade X valor homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaQuantidadeXValorHomeopatiaPorId/{id}")]
        public async Task<JsonResult> RetornaQuantidadeXValorHomeopatiaPorId(int id)
        {
            try
            {
                return Json(await this.IQuantidadeXValorHomeopatia.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a quantidade X valor homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarQuantidadeXValorHomeopatia")]
        public async Task<JsonResult> EditarQuantidadeXValorHomeopatia([FromBody] QuantidadeXValorHomeopatia QuantidadeXValorHomeopatia)
        {
            try
            {
                if (QuantidadeXValorHomeopatia.QuantidadeInicial <= 0 ||
                    QuantidadeXValorHomeopatia.QuantidadeFinal <= 0 ||
                    QuantidadeXValorHomeopatia.ValorVenda <= 0 ||
                    QuantidadeXValorHomeopatia.ValorAdicional <= 0 ||
                    QuantidadeXValorHomeopatia.IntervaloDinamizacaoId <= 0 ||
                    QuantidadeXValorHomeopatia.QuantidadeFinal < QuantidadeXValorHomeopatia.QuantidadeInicial
                    )
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IQuantidadeXValorHomeopatia.Update(QuantidadeXValorHomeopatia)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a quantidade X valor homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirQuantidadeXValorHomeopatia")]
        public async Task<JsonResult> ExcluirQuantidadeXValorHomeopatia([FromBody] QuantidadeXValorHomeopatia QuantidadeXValorHomeopatia)
        {
            try
            {
                Json(await Task.FromResult(this.IQuantidadeXValorHomeopatia.Delete(QuantidadeXValorHomeopatia)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a quantidade X valor homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
