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

        [HttpGet("/api/ListaPaginacaoNcmEstado/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var ncmEstados = await this.INcmEstado.List();

                var total = Convert.ToDouble(ncmEstados.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.INcmEstado.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : ncmEstados);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os ncm dos estados " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarNcmEstado([FromBody] NcmEstado NcmEstado)
        {
            try
            {
                if (NcmEstado.EstadoOrigemId <= 0)
                    return BadRequest("Campo de estado de origem é obrigatório");
                if (NcmEstado.EstadoDestinoId <= 0)
                    return BadRequest("Campo de estado de destino é obrigatório");
                if (NcmEstado.NcmId <= 0)
                    return BadRequest("Campo de Ncm é obrigatório");

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
                return Json(await this.INcmEstado.GetEntityById(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o ncm de estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarNcmEstado")]
        public async Task<IActionResult> EditarNcmEstado([FromBody] NcmEstado NcmEstado)
        {
            try
            {
                if (NcmEstado.EstadoOrigemId <= 0)
                    return BadRequest("Campo de estado de origem é obrigatório");
                if (NcmEstado.EstadoDestinoId <= 0)
                    return BadRequest("Campo de estado de destino é obrigatório");
                if (NcmEstado.NcmId <= 0)
                    return BadRequest("Campo de Ncm é obrigatório");

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
                Json(await Task.FromResult(this.INcmEstado.Delete(NcmEstado)));
                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o ncm de estado " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
