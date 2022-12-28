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
    public class NcmEstadoApiController: Controller
    {
        private readonly INcmEstado INcmEstado;

        public NcmEstadoApiController(INcmEstado INcmEstado)
        {
            this.INcmEstado = INcmEstado;
        }

        [HttpGet("/api/ListaNcmEstado")]
        public async Task<JsonResult> ListaNcmEstado()
        {
            try
            {
                return Json(await this.INcmEstado.List());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os ncm de estado " + ex.Message }) { StatusCode = 400 };
            }

        }

        [HttpPost("/api/AdicionarNcmEstado")]
        public async Task<JsonResult> AdicionarNcmEstado([FromBody] NcmEstado NcmEstado)
        {
            try
            {
                if (NcmEstado.EstadoOrigemId <= 0 || NcmEstado.EstadoDestinoId <= 0 || NcmEstado.NcmId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.INcmEstado.Add(NcmEstado)));

                return Json(Ok());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o ncm de estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaNcmEstadoPorId/{id}")]
        public async Task<JsonResult> RetornaNcmEstadoPorId(int id)
        {
            try
            {
                return Json(await this.INcmEstado.GetNcmEstado(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o ncm de estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarNcmEstado")]
        public async Task<JsonResult> EditarNcmEstado([FromBody] NcmEstado NcmEstado)
        {
            try
            {
                if (NcmEstado.EstadoOrigemId <= 0 || NcmEstado.EstadoDestinoId <= 0 || NcmEstado.NcmId <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.INcmEstado.Update(NcmEstado)));
                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o ncm de estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirNcmEstado")]
        public async Task<JsonResult> ExcluirNcmEstado([FromBody] NcmEstado NcmEstado)
        {
            try
            {
                return Json(await Task.FromResult(this.INcmEstado.Delete(NcmEstado)));
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o ncm de estado " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
