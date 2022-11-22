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
    public class MoedaApiController : Controller
    {
        private readonly IMoeda IMoeda;

        public MoedaApiController(IMoeda imoeda)
        {
            IMoeda = imoeda;
        }
        [HttpGet("/api/ListaMoeda")]
        public async Task<JsonResult> ListaMoeda()
        {
            return Json(await this.IMoeda.List());
        }
        [HttpPost("/api/AdicionarMoeda")]
        public async Task<JsonResult> AdicionarMoeda([FromBody] Moeda moeda)
        {
            if (string.IsNullOrEmpty(moeda.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IMoeda.Add(moeda)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarMoedaProId/{id}")]
        public async Task<JsonResult> RetornarMoedaProId(int id)
        {
            if (id == 0)
                return Json(BadRequest(ModelState));

            return Json(await this.IMoeda.GetEntityById(id));
        }
        [HttpPost("/api/EditarMoeda")]
        public async Task<JsonResult> EditarMoeda([FromBody] Moeda moeda)
        {
            if (string.IsNullOrEmpty(moeda.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IMoeda.Update(moeda)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirMoeda")]
        public async Task ExcluirMoeda([FromBody] Moeda moeda)
        {
            await Task.FromResult(this.IMoeda.Delete(moeda));
        }
    }
}
