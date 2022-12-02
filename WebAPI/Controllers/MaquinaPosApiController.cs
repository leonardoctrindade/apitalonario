using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class MaquinaPosApiController : Controller
    {
        private readonly IMaquinaPos IMaquinaPos;

        public MaquinaPosApiController(IMaquinaPos IMaquinaPos)
        {
            this.IMaquinaPos = IMaquinaPos;
        }

        [HttpGet("/api/ListaMaquinaPos")]
        public async Task<JsonResult> ListaMaquinaPos()
        {
            return Json(await this.IMaquinaPos.List());
        }

        [HttpGet("/api/AdicionarMaquinaPos")]
        public async Task<JsonResult> AdicionarMaquinaPos([FromBody] MaquinaPos MaquinaPos)
        {
            if (String.IsNullOrEmpty(MaquinaPos.SerialPos))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IMaquinaPos.Add(MaquinaPos)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaMaquinaPosPorId/{id}")]
        public async Task<JsonResult> RetornaMaquinaPosPorId(int id)
        {
            return Json(await this.IMaquinaPos.GetEntityById(id));
        }

        [HttpPost("/api/EditarMaquinaPos")]
        public async Task<JsonResult> EditarMaquinaPos([FromBody] MaquinaPos MaquinaPos)
        {
            if (String.IsNullOrEmpty(MaquinaPos.SerialPos))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IMaquinaPos.Update(MaquinaPos)));
            return Json(Ok());
        }

        [HttpPost("/api/ExlcuirMaquinaPos")]
        public async Task ExcluirMaquinaPos([FromBody] MaquinaPos MaquinaPos)
        {
            await Task.FromResult(this.IMaquinaPos.Delete(MaquinaPos));
        }
    }
}
