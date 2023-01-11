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
    public class VolumeXValorHomeopatiaApiController : Controller
    {
        private readonly IVolumeXValorHomeopatia IVolumeXValorHomeopatia;

        public VolumeXValorHomeopatiaApiController(IVolumeXValorHomeopatia IVolumeXValorHomeopatia)
        {
            this.IVolumeXValorHomeopatia = IVolumeXValorHomeopatia;
        }

        [HttpGet("/api/ListaVolumeXValorHomeopatia")]
        public async Task<JsonResult> ListaVolumeXValorHomeopatia()
        {
            try
            {
                return Json(await this.IVolumeXValorHomeopatia.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os volumesXValorHomeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarVolumeXValorHomeopatia")]
        public async Task<JsonResult> AdicionarVolumeXValorHomeopatia([FromBody] VolumeXValorHomeopatia VolumeXValorHomeopatia)
        {
            try
            {
                if (VolumeXValorHomeopatia.Volume <= 0 || VolumeXValorHomeopatia.IntervaloDinamizacaoId <= 0 || VolumeXValorHomeopatia.ValorVenda <= 0 || VolumeXValorHomeopatia.ValorAdicional <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IVolumeXValorHomeopatia.Add(VolumeXValorHomeopatia)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o volumeXValorHomeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaVolumeXValorHomeopatiaPorId/{id}")]
        public async Task<JsonResult> RetornaVolumeXValorHomeopatiaPorId(int id)
        {
            try
            {
                return Json(await this.IVolumeXValorHomeopatia.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o volumeXValorHomeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarVolumeXValorHomeopatia")]
        public async Task<JsonResult> EditarVolumeXValorHomeopatia([FromBody] VolumeXValorHomeopatia VolumeXValorHomeopatia)
        {
            try
            {
                if (VolumeXValorHomeopatia.Volume <= 0 || VolumeXValorHomeopatia.IntervaloDinamizacaoId <= 0 || VolumeXValorHomeopatia.ValorVenda <= 0 || VolumeXValorHomeopatia.ValorAdicional <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IVolumeXValorHomeopatia.Update(VolumeXValorHomeopatia)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o volumeXValorHomeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirVolumeXValorHomeopatia")]
        public async Task<JsonResult> ExcluirVolumeXValorHomeopatia([FromBody] VolumeXValorHomeopatia VolumeXValorHomeopatia)
        {
            try
            {
                Json(await Task.FromResult(this.IVolumeXValorHomeopatia.Delete(VolumeXValorHomeopatia)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o volumeXValorHomeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
