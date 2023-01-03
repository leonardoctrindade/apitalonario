using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class BulaApiController : Controller
    {
        private readonly IBula IBula;

        public BulaApiController(IBula IBula)
        {
            this.IBula = IBula;
        }

        [HttpGet("/api/ListaBula")]
        public async Task<JsonResult> ListaBula()
        {
            try
            {
                return Json(await this.IBula.List());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as bulas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarBula")]
        public async Task<JsonResult> AdicionarBula([FromBody] Bula Bula)
        {
            try
            {
                if (String.IsNullOrEmpty(Bula.Descricao))
                    return Json(BadRequest(ModelState));
                if (Bula.Tipo != 1 && Bula.Tipo != 2)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IBula.Add(Bula)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a bula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaBulaPorId/{id}")]
        public async Task<JsonResult> RetornaBulaPorId(int id)
        {
            try
            {
                return Json(await this.IBula.GetEntityById(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a bula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarBula")]
        public async Task<JsonResult> EditarBula([FromBody] Bula Bula)
        {
            try
            {
                if (String.IsNullOrEmpty(Bula.Descricao))
                    return Json(BadRequest(ModelState));
                if (Bula.Tipo != 1 && Bula.Tipo != 2)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IBula.Update(Bula)));
                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar a bula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirBula")]
        public async Task<JsonResult> ExcluirBula([FromBody] Bula Bula)
        {
            try
            {
                Json(await Task.FromResult(this.IBula.Delete(Bula)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir a bula " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
