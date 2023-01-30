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

        [HttpGet("/api/ListaPaginacaoCategoria/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var categorias = await this.ICategoria.List();

                var total = Convert.ToDouble(categorias.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ICategoria.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : categorias);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as categorias " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarCategoria([FromBody] Categoria Categoria)
        {
            try
            {
                if (String.IsNullOrEmpty(Categoria.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

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
                return Json(await this.ICategoria.GetCategoria(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retorna a categoria " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarCategoria")]
        public async Task<IActionResult> EditarCategoria([FromBody] Categoria Categoria)
        {
            try
            {
                if (String.IsNullOrEmpty(Categoria.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

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
                Json(await Task.FromResult(this.ICategoria.Delete(Categoria)));
                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir a categoria " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
