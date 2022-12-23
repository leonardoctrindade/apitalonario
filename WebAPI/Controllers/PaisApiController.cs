using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class PaisApiController : Controller
    {
        private readonly IPais IPais;

        public PaisApiController(IPais IPais)
        {
            this.IPais = IPais;
        }

        [HttpGet("/api/ListaPais")]
        public async Task<JsonResult> ListaPais()
        {
            try
            {
                return Json(await this.IPais.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os paises " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarPais")]
        public async Task<JsonResult> AdicionarPais([FromBody] Pais Pais)
        {
            try
            {
                if (String.IsNullOrEmpty(Pais.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPais.Add(Pais)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o pais " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaPaisPorId/{id}")]
        public async Task<JsonResult> RetornaPaisPorId(int id)
        {
            try
            {
                return Json(await this.IPais.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o pais " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPais")]
        public async Task<JsonResult> EditarPais([FromBody] Pais Pais)
        {
            try
            {
                if (String.IsNullOrEmpty(Pais.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPais.Update(Pais)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o pais " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPais")]
        public async Task<JsonResult> ExcluirPais([FromBody] Pais Pais)
        {
            try
            {
                return Json(await Task.FromResult(this.IPais.Delete(Pais)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o pais " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
