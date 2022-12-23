using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class EnsaioApiController : Controller
    {
        private readonly IEnsaio IEnsaio;

        public EnsaioApiController(IEnsaio IEnsaio)
        {
            this.IEnsaio = IEnsaio;
        }

        [HttpGet("/api/ListaEnsaio")]
        public async Task<JsonResult> ListaEnsaio()
        {
            try
            {
                return Json(await this.IEnsaio.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os ensaios " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEnsaio")]
        public async Task<JsonResult> AdicionarEnsaio([FromBody] Ensaio Ensaio)
        {
            try
            {
                if (String.IsNullOrEmpty(Ensaio.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEnsaio.Add(Ensaio)));

                return Json(Ok());
            } 
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaEnsaioPorId/{id}")]
        public async Task<JsonResult> RetornaEnsaioPorId(int id)
        {
            try
            {
                return Json(await this.IEnsaio.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEnsaio")]
        public async Task<JsonResult> EditarEnsaio([FromBody] Ensaio Ensaio)
        {
            try
            {
                if (String.IsNullOrEmpty(Ensaio.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IEnsaio.Update(Ensaio)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEnsaio")]
        public async Task<JsonResult> ExcluirEnsaio([FromBody] Ensaio Ensaio)
        {
            try 
            {
                return Json(await Task.FromResult(this.IEnsaio.Delete(Ensaio)));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o ensaio " + ex.Message }) { StatusCode = 400 };
            }  
        }
    }
}
