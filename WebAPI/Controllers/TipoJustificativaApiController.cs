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
    public class TipoJustificativaApiController : Controller
    {
        private readonly ITipoJustificativa ITipoJustificativa;
        public TipoJustificativaApiController(ITipoJustificativa itipoJustificativa)
        {
            this.ITipoJustificativa = itipoJustificativa;
        }
        [HttpGet("/api/ListaTipoJustificativa")]
        public async Task<JsonResult> ListaTipoJustificativa()
        {
            return Json(await this.ITipoJustificativa.List());
        }
        [HttpPost("/api/AdicionarTipoJustificativa")]
        public async Task<JsonResult> AdicionarTipoJustificativa([FromBody] TipoJustificativa tipoJustificativa)
        {
            if (string.IsNullOrEmpty(tipoJustificativa.Descricao))
                return Json(BadRequest(ModelState));

            try
            {
                return Json(await Task.FromResult(this.ITipoJustificativa.Add(tipoJustificativa)));
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
        }
        [HttpGet("/api/RetornarTipoJustificativaPorId/{id}")]
        public async Task<JsonResult> RetornarTipoJustificativaPorId(int id)
        {
            return Json(await this.ITipoJustificativa.GetEntityById(id));
        }
        [HttpPost("/api/EditarTipoJustificativa")]
        public async Task<JsonResult> EditarTipoJustificativa([FromBody] TipoJustificativa tipoJustificativa)
        {
            if (string.IsNullOrEmpty(tipoJustificativa.Descricao))
                return Json(BadRequest(ModelState));

            try
            {
                return Json(await Task.FromResult(this.ITipoJustificativa.Update(tipoJustificativa)));
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
        }
        [HttpPost("/api/ExcluiTipoJustificativa")]
        public async Task ExcluiTipoJustificativa([FromBody] TipoJustificativa tipoJustificativa)
        {
            await Task.FromResult(this.ITipoJustificativa.Delete(tipoJustificativa));
        }
    }
}
