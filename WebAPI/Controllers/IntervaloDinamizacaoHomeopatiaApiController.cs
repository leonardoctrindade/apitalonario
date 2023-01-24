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
    public class IntervaloDinamizacaoHomeopatiaApiController : Controller
    {
        private readonly IIntervaloDinamizacaoHomeopatia IIntervaloDinamizacaoHomeopatia;

        public IntervaloDinamizacaoHomeopatiaApiController(IIntervaloDinamizacaoHomeopatia IIntervaloDinamizacaoHomeopatia)
        {
            this.IIntervaloDinamizacaoHomeopatia = IIntervaloDinamizacaoHomeopatia;
        }

        [HttpGet("/api/ListaPaginacaoIntervaloDinamizacaoHomeopatia/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var intervalos = await this.IIntervaloDinamizacaoHomeopatia.List();

                var total = Convert.ToDouble(intervalos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IIntervaloDinamizacaoHomeopatia.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : intervalos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os intervalos de dinamização de homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaIntervaloDinamizacaoHomeopatia")]
        public async Task<JsonResult> ListaIntervaloDinamizacaoHomeopatia()
        {
            try
            {
                return Json(await this.IIntervaloDinamizacaoHomeopatia.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os bairros " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarIntervaloDinamizacaoHomeopatia")]
        public async Task<IActionResult> AdicionarIntervaloDinamizacaoHomeopatia([FromBody] IntervaloDinamizacaoHomeopatia IntervaloDinamizacaoHomeopatia)
        {
            try
            {
                if (IntervaloDinamizacaoHomeopatia.Inicial <= 0)
                    return BadRequest("Campo inicial é obrigatório");
                if (IntervaloDinamizacaoHomeopatia.Final <= 0)
                    return BadRequest("Campo final é obrigatório");
                if (IntervaloDinamizacaoHomeopatia.TabelaHomeopatiaId <= 0)
                    return BadRequest("Campo tabela homeopatia é obrigatório");
                if (IntervaloDinamizacaoHomeopatia.Final < IntervaloDinamizacaoHomeopatia.Inicial)
                    return BadRequest("Campo final não pode ser menor que o inicial");

                Json(await Task.FromResult(this.IIntervaloDinamizacaoHomeopatia.Add(IntervaloDinamizacaoHomeopatia)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o intervalo dinamizacao homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaIntervaloDinamizacaoHomeopatiaPorId/{id}")]
        public async Task<JsonResult> RetornaIntervaloDinamizacaoHomeopatiaPorId(int id)
        {
            try
            {
                return Json(await this.IIntervaloDinamizacaoHomeopatia.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o intervalo dinamizacao homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarIntervaloDinamizacaoHomeopatia")]
        public async Task<IActionResult> EditarIntervaloDinamizacaoHomeopatia([FromBody] IntervaloDinamizacaoHomeopatia IntervaloDinamizacaoHomeopatia)
        {
            try
            {
                if (IntervaloDinamizacaoHomeopatia.Inicial <= 0)
                    return BadRequest("Campo inicial é obrigatório");
                if (IntervaloDinamizacaoHomeopatia.Final <= 0)
                    return BadRequest("Campo final é obrigatório");
                if (IntervaloDinamizacaoHomeopatia.TabelaHomeopatiaId <= 0)
                    return BadRequest("Campo tabela homeopatia é obrigatório");
                if (IntervaloDinamizacaoHomeopatia.Final < IntervaloDinamizacaoHomeopatia.Inicial)
                    return BadRequest("Campo final não pode ser menor que o inicial");

                Json(await Task.FromResult(this.IIntervaloDinamizacaoHomeopatia.Update(IntervaloDinamizacaoHomeopatia)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o intervalo dinamizacao homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirIntervaloDinamizacaoHomeopatia")]
        public async Task<JsonResult> ExcluirIntervaloDinamizacaoHomeopatia([FromBody] IntervaloDinamizacaoHomeopatia IntervaloDinamizacaoHomeopatia)
        {
            try
            {
                Json(await Task.FromResult(this.IIntervaloDinamizacaoHomeopatia.Delete(IntervaloDinamizacaoHomeopatia)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o intervalo dinamizacao homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
