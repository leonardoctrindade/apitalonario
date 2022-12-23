using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class NcmApiController : Controller
    {
        private readonly INcm INcm;

        public NcmApiController(INcm INcm)
        {
            this.INcm = INcm;
        }

        [HttpGet("/api/ListaNcm")]
        public async Task<JsonResult> ListaNcm()
        {
            try
            {
                return Json(await this.INcm.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os ncms " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarNcm")]
        public async Task<JsonResult> AdicionarNcm([FromBody] Ncm Ncm)
        {
            try
            {
                if (String.IsNullOrEmpty(Ncm.Descricao))
                    return Json(BadRequest(ModelState));
                if (string.IsNullOrEmpty(Ncm.CodigoNcm))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.INcm.Add(Ncm)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o ncm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaNcmPorId/{id}")]
        public async Task<JsonResult> RetornaNcmPorId(int id)
        {
            try
            {
                return Json(await this.INcm.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o ncm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarNcm")]
        public async Task<JsonResult> EditarNcm([FromBody] Ncm Ncm)
        {
            try
            {
                if (String.IsNullOrEmpty(Ncm.Descricao))
                    return Json(BadRequest(ModelState));
                if (string.IsNullOrEmpty(Ncm.CodigoNcm))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.INcm.Update(Ncm)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o ncm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirNcm")]
        public async Task<JsonResult> ExcluirNcm([FromBody] Ncm Ncm)
        {
            try
            {
                return Json(await Task.FromResult(this.INcm.Delete(Ncm)));
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o ncm " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
