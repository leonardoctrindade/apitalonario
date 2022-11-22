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
    public class TributoApiController : Controller
    {
        private readonly ITributo ITributo;

        public TributoApiController(ITributo ITributo)
        {
            this.ITributo = ITributo;
        }

        [HttpGet("/api/ListaTributo")]
        public async Task<JsonResult> ListaTributo()
        {
            return Json(await this.ITributo.List());
        }

        [HttpPost("/api/AdicionarTributo")]
        public async Task<JsonResult> AdicionarTributo([FromBody] Tributo Tributo)
        {
            if (string.IsNullOrEmpty(Tributo.Codigo))
                return Json(BadRequest(ModelState));
            if (string.IsNullOrEmpty(Tributo.Descricao))
                return Json(BadRequest(ModelState));
            //if (Tributo.Equals(Tributo.Tipo, null))
                //return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITributo.Add(Tributo)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaTributoPorId/{id}")]
        public async Task<JsonResult> RetornaTributoPorId(int id)
        {
            return Json(await this.ITributo.GetEntityById(id));
        }

        [HttpPost("/api/EditarTributo")]
        public async Task<JsonResult> EditarTributo([FromBody] Tributo Tributo)
        {
            if (string.IsNullOrEmpty(Tributo.Codigo))
                return Json(BadRequest(ModelState));
            if (string.IsNullOrEmpty(Tributo.Descricao))
                return Json(BadRequest(ModelState));
            //if (Tributo.Equals(Tributo.Tipo, null))
                //return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITributo.Update(Tributo)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirTributo")]
        public async Task ExcluirTributo([FromBody] Tributo Tributo)
        {
            await Task.FromResult(this.ITributo.Delete(Tributo));
        }
    }
}
