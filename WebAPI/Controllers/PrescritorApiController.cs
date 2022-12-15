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
            return Json(await this.IPrescritor.GetEntityById(id));
        }
        [HttpPost("/api/EditarPrescritor")]
        public async Task<JsonResult> EditarPrescritor([FromBody] Prescritor prescritor)
        {
            if (string.IsNullOrEmpty(prescritor.Nome) || string.IsNullOrEmpty(prescritor.CrmEstado)
                || string.IsNullOrEmpty(prescritor.CrmNumero))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPrescritor.Update(prescritor)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirPrescritor")]
        public async Task ExcluirPrescritor([FromBody] Prescritor prescritor)
        {
            await Task.FromResult(this.IPrescritor.Delete(prescritor));
        }
    }
}
