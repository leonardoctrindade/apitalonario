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
    public class EstadoApiController : Controller
    {
        private readonly IEstado IEstado;

        public EstadoApiController(IEstado IEstado)
        {
            this.IEstado = IEstado;
        }

        [HttpGet("/api/ListaEstado")]
        public async Task<JsonResult> ListaEstado()
        {
            try
            {
                return Json(await this.IEstado.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os estados " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEstado")]
        public async Task<JsonResult> AdicionarEstado([FromBody] Estado Estado)
        {
            try
            {
                if (String.IsNullOrEmpty(Estado.Nome))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Estado.Sigla) || Estado.Sigla.Count() != 2)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEstado.Add(Estado)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaEstadoPorId/{id}")]
        public async Task<JsonResult> RetornaEstadoPorId(int id)
        {
            try
            {
                return Json(await this.IEstado.GetEstado(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEstado")]
        public async Task<JsonResult> EditarEstado([FromBody] Estado Estado)
        {
            try
            {
                if (String.IsNullOrEmpty(Estado.Nome))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(Estado.Sigla) || Estado.Sigla.Count() != 2)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEstado.Update(Estado)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o estado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEstado")]
        public async Task<JsonResult> ExcluirEstado([FromBody] Estado Estado)
        {
            try
            {
                return Json(await Task.FromResult(this.IEstado.Delete(Estado)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o estado " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
