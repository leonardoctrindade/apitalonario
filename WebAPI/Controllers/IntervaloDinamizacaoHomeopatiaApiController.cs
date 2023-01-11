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
        public async Task<JsonResult> AdicionarIntervaloDinamizacaoHomeopatia([FromBody] IntervaloDinamizacaoHomeopatia IntervaloDinamizacaoHomeopatia)
        {
            try
            {
                if (IntervaloDinamizacaoHomeopatia.Inicial <= 0 || IntervaloDinamizacaoHomeopatia.Final <= 0 || IntervaloDinamizacaoHomeopatia.TabelaHomeopatiaId <= 0)
                    return Json(BadRequest(ModelState));

                if (IntervaloDinamizacaoHomeopatia.Final < IntervaloDinamizacaoHomeopatia.Inicial)
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarIntervaloDinamizacaoHomeopatia([FromBody] IntervaloDinamizacaoHomeopatia IntervaloDinamizacaoHomeopatia)
        {
            try
            {
                if (IntervaloDinamizacaoHomeopatia.Inicial <= 0 || IntervaloDinamizacaoHomeopatia.Final <= 0 || IntervaloDinamizacaoHomeopatia.TabelaHomeopatiaId <= 0)
                    return Json(BadRequest(ModelState));

                if (IntervaloDinamizacaoHomeopatia.Final < IntervaloDinamizacaoHomeopatia.Inicial)
                    return Json(BadRequest(ModelState));

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
