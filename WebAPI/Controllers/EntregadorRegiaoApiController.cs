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
    public class EntregadorRegiaoApiController : Controller
    {
        private readonly IEntregadorRegiao IEntregadorRegiao;

        public EntregadorRegiaoApiController(IEntregadorRegiao IEntregadorRegiao)
        {
            this.IEntregadorRegiao = IEntregadorRegiao;
        }

        [HttpGet("/api/ListaEntregadorRegiao")]
        public async Task<JsonResult> ListaEntregadorRegiao()
        {
            return Json(await this.IEntregadorRegiao.List());
        }

        [HttpPost("/api/AdicionarEntregadorRegiao")]
        public async Task<JsonResult> AdicionarEntregadorRegiao([FromBody] EntregadorRegiao EntregadorRegiao)
        {
            if (EntregadorRegiao.IdEntregador == 0 || EntregadorRegiao.IdRegiao == 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEntregadorRegiao.Add(EntregadorRegiao)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaEntregadorRegiaoPorId/{id}")]
        public async Task<JsonResult> RetornaEntregadorRegiaoPorId(int id)
        {
            return Json(await this.IEntregadorRegiao.GetEntityById(id));
        }

        [HttpPost("/api/EditarEntregadorRegiao")]
        public async Task<JsonResult> EditarEntregadorRegiao([FromBody] EntregadorRegiao EntregadorRegiao)
        {
            if (EntregadorRegiao.IdEntregador == 0 || EntregadorRegiao.IdRegiao == 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IEntregadorRegiao.Update(EntregadorRegiao)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirEntregadorRegiao")]
        public async Task ExcluirEntregadorRegiao([FromBody] EntregadorRegiao EntregadorRegiao)
        {
            await Task.FromResult(this.IEntregadorRegiao.Delete(EntregadorRegiao));
        }
    }
}
