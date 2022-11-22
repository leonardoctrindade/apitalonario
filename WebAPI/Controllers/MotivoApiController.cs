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
    public class MotivoApiController : Controller
    {
        private readonly IMotivo IMotivo;

        public MotivoApiController(IMotivo imotivo)
        {
            IMotivo = imotivo;
        }
        [HttpGet("/api/ListaMotivo")]
        public async Task<JsonResult> ListaMotivo()
        {
            return Json(await this.IMotivo.List());
        }
        [HttpPost("/api/AdicionarMotivo")]
        public async Task<JsonResult> AdicionarMotivo([FromBody] Motivo motivo)
        {
            if (string.IsNullOrEmpty(motivo.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IMotivo.Add(motivo)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarMotivoPorId/{id}")]
        public async Task<JsonResult> RetornarMotivoPorId(int id)
        {
            if (id == 0)
                return Json(BadRequest(ModelState));

            return Json(await this.IMotivo.GetEntityById(id));
        }
        [HttpPost("/api/EditarMotivo")]
        public async Task<JsonResult> EditarMotivo([FromBody] Motivo motivo)
        {
            if (string.IsNullOrEmpty(motivo.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IMotivo.Update(motivo)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirMotivo")]
        public async Task ExcluirMotivo([FromBody] Motivo motivo)
        {
            await Task.FromResult(this.IMotivo.Delete(motivo));
        }
    }
}
