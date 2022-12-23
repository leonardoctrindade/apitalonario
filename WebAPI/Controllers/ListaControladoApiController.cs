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
            try
            {
                return Json(await this.IListaControlado.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as listas de controlados " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarListaControlado")]
        public async Task<JsonResult> AdicionarListaControlado([FromBody] ListaControlado ListaControlado)
        {
            try
            {
                if (String.IsNullOrEmpty(ListaControlado.Descricao))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(ListaControlado.Codigo))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IListaControlado.Add(ListaControlado)));

                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a lista de controlado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaListaControladoPorId/{id}")]
        public async Task<JsonResult> RetornaListaControladoPorId(int id)
        {
            try
            {
                return Json(await this.IListaControlado.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a lista de controlado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarListaControlado")]
        public async Task<JsonResult> EditarListaControlado([FromBody] ListaControlado ListaControlado)
        {
            try
            {
                if (String.IsNullOrEmpty(ListaControlado.Descricao))
                    return Json(BadRequest(ModelState));
                if (String.IsNullOrEmpty(ListaControlado.Codigo))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IListaControlado.Update(ListaControlado)));
                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar a lista de controlado " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirListaControlado")]
        public async Task<JsonResult> ExcluirListaControlado([FromBody] ListaControlado ListaControlado)
        {
            try
            {
                return Json(await Task.FromResult(this.IListaControlado.Delete(ListaControlado)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a lista de controlado " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
