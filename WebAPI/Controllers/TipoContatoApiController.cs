using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class TipoContatoApiController: Controller
    {
        private readonly ITipoContato ITipoContato;

        public TipoContatoApiController(ITipoContato ITipoContato)
        {
            this.ITipoContato = ITipoContato;
        }

        [HttpGet("/api/ListaTipoContato")]
        public async Task<JsonResult> ListaTipoContato()
        {
            return Json(await this.ITipoContato.List());
        }

        [HttpPost("/api/AdicionarTipoContato")]
        public async Task<JsonResult> AdicionarTipoContato([FromBody] TipoContato TipoContato)
        {
            if (String.IsNullOrEmpty(TipoContato.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITipoContato.Add(TipoContato)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaTipoContatoPorId/{id}")]
        public async Task<JsonResult> RetornaTipoContatoPorId(int id)
        {
            return Json(await this.ITipoContato.GetEntityById(id));
        }

        [HttpPost("/api/EditarTipoContato")]
        public async Task<JsonResult> EditarTipoContato([FromBody] TipoContato TipoContato)
        {
            if (String.IsNullOrEmpty(TipoContato.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ITipoContato.Update(TipoContato)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirTipoContato")]
        public async Task ExcluirTipoContato([FromBody] TipoContato TipoContato)
        {
            await Task.FromResult(this.ITipoContato.Delete(TipoContato));
        }
    }
}
