using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class MetodoApiController: Controller
    {
        private readonly IMetodo IMetodo;

        public MetodoApiController(IMetodo IMetodo)
        {
            this.IMetodo = IMetodo;
        }

        [HttpGet("/api/ListaMetodo")]
        public async Task<JsonResult> ListaMetodo()
        {
            return Json(await this.IMetodo.List());
        }

        [HttpPost("/api/AdicionarMetodo")]
        public async Task<JsonResult> AdicionarMetodo([FromBody] Metodo Metodo)
        {
            if (String.IsNullOrEmpty(Metodo.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IMetodo.Add(Metodo)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaMetodoPorId/{id}")]
        public async Task<JsonResult> RetornaMetodoPorId(int id)
        {
            return Json(await this.IMetodo.GetEntityById(id));
        }

        [HttpPost("/api/EditarMetodo")]
        public async Task<JsonResult> EditarMetodo([FromBody] Metodo Metodo)
        {
            if (String.IsNullOrEmpty(Metodo.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IMetodo.Update(Metodo)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirMetodo")]
        public async Task ExcluirMetodo([FromBody] Metodo Metodo)
        {
            await Task.FromResult(this.IMetodo.Delete(Metodo));
        }
    }
}
