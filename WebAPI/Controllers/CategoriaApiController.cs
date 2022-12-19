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
    public class CategoriaApiController : Controller
    {
        private readonly ICategoria ICategoria;

        public CategoriaApiController(ICategoria ICategoria)
        {
            this.ICategoria = ICategoria;
        }

        [HttpGet("/api/ListaCategoria")]
        public async Task<JsonResult> ListaCategoria()
        {
            return Json(await this.ICategoria.List());
        }

        [HttpPost("/api/AdicionarCategoria")]
        public async Task<JsonResult> AdicionarCategoria([FromBody] Categoria Categoria)
        {
            if (String.IsNullOrEmpty(Categoria.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ICategoria.Add(Categoria)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaCategoriaPorId/{id}")]
        public async Task<JsonResult> RetornaCategoriaPorId(int id)
        {
            return Json(await this.ICategoria.GetEntityById(id));
        }

        [HttpPost("/api/EditarCategoria")]
        public async Task<JsonResult> EditarCategoria([FromBody] Categoria Categoria)
        {
            if (String.IsNullOrEmpty(Categoria.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ICategoria.Update(Categoria)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirCategoria")]
        public async Task ExcluirCategoria([FromBody] Categoria Categoria)
        {
            await Task.FromResult(this.ICategoria.Delete(Categoria));
        }
    }
}
