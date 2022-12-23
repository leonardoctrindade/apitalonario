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
            try
            {
                return Json(await this.IMetodo.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os metodos " + ex.Message }) { StatusCode = 400 };
            } 
        }

        [HttpPost("/api/AdicionarMetodo")]
        public async Task<JsonResult> AdicionarMetodo([FromBody] Metodo Metodo)
        {
            try
            {
                if (String.IsNullOrEmpty(Metodo.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IMetodo.Add(Metodo)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o metodo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaMetodoPorId/{id}")]
        public async Task<JsonResult> RetornaMetodoPorId(int id)
        {
            try
            {
                return Json(await this.IMetodo.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o metodo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarMetodo")]
        public async Task<JsonResult> EditarMetodo([FromBody] Metodo Metodo)
        {
            try
            {
                if (String.IsNullOrEmpty(Metodo.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IMetodo.Update(Metodo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o metodo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirMetodo")]
        public async Task<JsonResult> ExcluirMetodo([FromBody] Metodo Metodo)
        {
            try
            {
                return Json(await Task.FromResult(this.IMetodo.Delete(Metodo)));
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o metodo " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
