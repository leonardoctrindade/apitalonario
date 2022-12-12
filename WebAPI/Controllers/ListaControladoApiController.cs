using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class ListaControladoApiController: Controller
    {
        private readonly IListaControlado IListaControlado;

        public ListaControladoApiController(IListaControlado IListaControlado)
        {
            this.IListaControlado = IListaControlado;
        }

        [HttpGet("/api/ListaListaControlado")]
        public async Task<JsonResult> ListaListaControlado()
        {
            return Json(await this.IListaControlado.List());
        }

        [HttpPost("/api/AdicionarListaControlado")]
        public async Task<JsonResult> AdicionarListaControlado([FromBody] ListaControlado ListaControlado)
        {
            if (String.IsNullOrEmpty(ListaControlado.Descricao))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(ListaControlado.Codigo))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IListaControlado.Add(ListaControlado)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaListaControladoPorId/{id}")]
        public async Task<JsonResult> RetornaListaControladoPorId(int id)
        {
            return Json(await this.IListaControlado.GetEntityById(id));
        }

        [HttpPost("/api/EditarListaControlado")]
        public async Task<JsonResult> EditarListaControlado([FromBody] ListaControlado ListaControlado)
        {
            if (String.IsNullOrEmpty(ListaControlado.Descricao))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(ListaControlado.Codigo))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IListaControlado.Update(ListaControlado)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirListaControlado")]
        public async Task ExcluirListaControlado([FromBody] ListaControlado ListaControlado)
        {
            await Task.FromResult(this.IListaControlado.Delete(ListaControlado));
        }
    }
}
