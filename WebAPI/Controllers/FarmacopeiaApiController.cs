using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

namespace WebAPI.Controllers
{
    [Authorize]
    public class FarmacopeiaApiController : Controller
    {
        private readonly IFarmacopeia IFarmacopeia;

        public FarmacopeiaApiController(IFarmacopeia IFarmacopeia)
        {
            this.IFarmacopeia = IFarmacopeia;
        }

        [HttpGet("/api/ListaFarmacopeia")]
        public async Task<JsonResult> ListaFarmacopeia()
        {
            return Json(await this.IFarmacopeia.List());
        }

        [HttpPost("/api/AdicionarFarmacopeia")]
        public async Task<JsonResult> AdicioanarFarmacopeia([FromBody] Farmacopeia Farmacopeia)
        {
            if (String.IsNullOrEmpty(Farmacopeia.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFarmacopeia.Add(Farmacopeia)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaFarmacopeiaPorId/{id}")]
        public async Task<JsonResult> RetornaFarmacopeiaPorId(int id)
        {
            return Json(await this.IFarmacopeia.GetEntityById(id));
        }

        [HttpPost("/api/EditarFarmacopeia")]
        public async Task<JsonResult> EditarFarmacopeia([FromBody] Farmacopeia Farmacopeia)
        {
            if (String.IsNullOrEmpty(Farmacopeia.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFarmacopeia.Update(Farmacopeia)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirFarmacopeia")]
        public async Task ExcluirFarmacopeia([FromBody] Farmacopeia Farmacopeia)
        {
            await Task.FromResult(this.IFarmacopeia.Delete(Farmacopeia));
        }
    }
}
