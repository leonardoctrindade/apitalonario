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
    public class RegiaoApiController : Controller
    {
        private readonly IRegiao IRegiao;

        public RegiaoApiController(IRegiao IRegiao)
        {
            this.IRegiao = IRegiao;
        }

        [HttpGet("/api/ListaRegiao")]
        public async Task<JsonResult> ListaRegiao()
        {
            return Json(await this.IRegiao.List());
        }

        [HttpPost("/api/AdicionarRegiao")]
        public async Task<JsonResult> AdicionarRegiao([FromBody] Regiao Regiao)
        {
            if (String.IsNullOrEmpty(Regiao.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IRegiao.Add(Regiao)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaRegiaoPorId/{id}")]
        public async Task<JsonResult> RetornaRegiaoPorId(int id)
        {
            return Json(await this.IRegiao.GetEntityById(id));
        }

        [HttpPost("/api/EditarRegiao")]
        public async Task<JsonResult> EditarRegiao([FromBody] Regiao Regiao)
        {
            if (String.IsNullOrEmpty(Regiao.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IRegiao.Update(Regiao)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirRegiao")]
        public async Task ExcluirRegiao([FromBody] Regiao Regiao)
        {
            await Task.FromResult(this.IRegiao.Delete(Regiao));
        }
    }
}
