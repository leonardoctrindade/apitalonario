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

        [HttpGet("/api/ListaPaginacaoQuantidadeXValorHomeopatia/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var quantidades = await this.IQuantidadeXValorHomeopatia.List();

                var total = Convert.ToDouble(quantidades.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IQuantidadeXValorHomeopatia.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : quantidades);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os quantidades por valor homeopatia " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarQuantidadeXValorHomeopatia([FromBody] QuantidadeXValorHomeopatia QuantidadeXValorHomeopatia)
        {
            try
            {
                if (QuantidadeXValorHomeopatia.QuantidadeInicial < 0)
                    return BadRequest("Campo de quantidade inicial não pode ser menor que 0");
                if (QuantidadeXValorHomeopatia.QuantidadeFinal <= 0)
                    return BadRequest("Campo de quantidade final não pode ser menor ou igual a 0");
                if (QuantidadeXValorHomeopatia.ValorVenda <= 0)
                    return BadRequest("Campo de valor venda é obrigatório");
                if (QuantidadeXValorHomeopatia.ValorAdicional < 0)
                    return BadRequest("Campo de valor adicional é obrigatório");
                if (QuantidadeXValorHomeopatia.IntervaloDinamizacaoId <= 0)
                    return BadRequest("Campo de intervalo de dinamização é obrigatório");
                if (QuantidadeXValorHomeopatia.QuantidadeFinal < QuantidadeXValorHomeopatia.QuantidadeInicial)
                    return BadRequest("Campo de quantidade final não pode ser menor que de quantidade Inicial");

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
        public async Task<IActionResult> EditarQuantidadeXValorHomeopatia([FromBody] QuantidadeXValorHomeopatia QuantidadeXValorHomeopatia)
        {
            try
            {
                if (QuantidadeXValorHomeopatia.QuantidadeInicial < 0)
                    return BadRequest("Campo de quantidade inicial não pode ser menor que 0");
                if (QuantidadeXValorHomeopatia.QuantidadeFinal <= 0)
                    return BadRequest("Campo de quantidade final não pode ser menor ou igual a 0");
                if (QuantidadeXValorHomeopatia.ValorVenda <= 0)
                    return BadRequest("Campo de valor venda é obrigatório");
                if (QuantidadeXValorHomeopatia.ValorAdicional < 0)
                    return BadRequest("Campo de valor adicional é obrigatório");
                if (QuantidadeXValorHomeopatia.IntervaloDinamizacaoId <= 0)
                    return BadRequest("Campo de intervalo de dinamização é obrigatório");
                if (QuantidadeXValorHomeopatia.QuantidadeFinal < QuantidadeXValorHomeopatia.QuantidadeInicial)
                    return BadRequest("Campo de quantidade final não pode ser menor que de quantidade Inicial");

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
