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
            try
            {
                return Json(await this.ICategoria.List());
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as categorias " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarCategoria")]
        public async Task<JsonResult> AdicionarCategoria([FromBody] Categoria Categoria)
        {
            try
            {
                if (String.IsNullOrEmpty(Categoria.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ICategoria.Add(Categoria)));

                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a categoria " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaCategoriaPorId/{id}")]
        public async Task<JsonResult> RetornaCategoriaPorId(int id)
        {
            try
            {
                return Json(await this.ICategoria.GetEntityById(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retorna a categoria " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarCategoria")]
        public async Task<JsonResult> EditarCategoria([FromBody] Categoria Categoria)
        {
            try
            {
                if (String.IsNullOrEmpty(Categoria.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ICategoria.Update(Categoria)));
                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar a categoria " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirCategoria")]
        public async Task<JsonResult> ExcluirCategoria([FromBody] Categoria Categoria)
        {
            try
            {
                return Json(await Task.FromResult(this.ICategoria.Delete(Categoria)));
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir a categoria " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
