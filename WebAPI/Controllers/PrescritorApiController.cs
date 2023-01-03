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
    public class PrescritorApiController : Controller
    {
        private readonly IPrescritor IPrescritor;

        public PrescritorApiController(IPrescritor prescritor)
        {
            this.IPrescritor = prescritor;
        }

        [HttpGet("/api/ListaPrescritor")]
        public async Task<JsonResult> ListaPrescritor()
        {
            try
            {
                return Json(await this.IPrescritor.List());
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
            
        }
        [HttpPost("/api/AdicionarPrescritor")]
        public async Task<JsonResult> AdicionarPrescritor([FromBody] Prescritor prescritor)
        {
            if (string.IsNullOrEmpty(prescritor.Nome) || string.IsNullOrEmpty(prescritor.CrmEstado)
                || string.IsNullOrEmpty(prescritor.CrmNumero))
                return Json(BadRequest(ModelState));
            try
            {
                Json(await Task.FromResult(this.IPrescritor.Add(prescritor)));

            }
            catch (Exception)
            {

                throw;
            }
            

            return Json(Ok());
        }
        [HttpGet("/api/RetornarPrescritorPorId/{id}")]
        public async Task<JsonResult> RetornarPrescritorPorId(int id)
        {
            try
            {
                return Json(await this.IPrescritor.GetPrescritor(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPrescritor")]
        public async Task<JsonResult> EditarPrescritor([FromBody] Prescritor prescritor)
        {
            try
            {
                if (string.IsNullOrEmpty(prescritor.Nome) || string.IsNullOrEmpty(prescritor.CrmEstado)
                || string.IsNullOrEmpty(prescritor.CrmNumero))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPrescritor.Update(prescritor)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPrescritor")]
        public async Task<JsonResult> ExcluirPrescritor([FromBody] Prescritor prescritor)
        {
            try
            {
                Json(await Task.FromResult(this.IPrescritor.Delete(prescritor)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o prescritor " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
