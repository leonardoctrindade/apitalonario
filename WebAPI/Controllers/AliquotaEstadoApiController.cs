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
    public class AliquotaEstadoApiController: Controller
    {
        private readonly IAliquotaEstado IAliquotaEstado;

        public AliquotaEstadoApiController(IAliquotaEstado IAliquotaEstado)
        {
            this.IAliquotaEstado = IAliquotaEstado;
        }

        [HttpGet("/api/ListaAliquotaEstado")]
        public async Task<JsonResult> ListaAliquotaEstado()
        {
            try
            {
                return Json(await this.IAliquotaEstado.List());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as aliquotas de estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarAliquotaEstado")]
        public async Task<JsonResult> AdicionarAliquotaEstado([FromBody] AliquotaEstado AliquotaEstado)
        {
            try
            {
                Json(await Task.FromResult(this.IAliquotaEstado.Add(AliquotaEstado)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a aliquota de estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaAliquotaEstadoPorId/{id}")]
        public async Task<JsonResult> RetornaAliquotaEstadoPorId(int id)
        {
            try 
            {
                return Json(await this.IAliquotaEstado.GetEntityById(id));
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar a aliquota de estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarAliquotaEstado")]
        public async Task<JsonResult> EditarAliquotaEstado([FromBody] AliquotaEstado AliquotaEstado)
        {
            try
            {
                Json(await Task.FromResult(this.IAliquotaEstado.Update(AliquotaEstado)));

                return Json(Ok());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a aliquota de estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirAliquotaEstado")]
        public async Task<JsonResult> ExcluirAliquotaEstado([FromBody] AliquotaEstado AliquotaEstado)
        {
            try
            {
                return Json(await Task.FromResult(this.IAliquotaEstado.Delete(AliquotaEstado)));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a aliquota de estado " + ex.Message }) { StatusCode = 400 };
            }
            
        }
    }
}
