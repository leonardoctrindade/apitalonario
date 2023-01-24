using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class MetodoApiController: Controller
    {
        private readonly IMetodo IMetodo;

        public MetodoApiController(IMetodo IMetodo)
        {
            this.IMetodo = IMetodo;
        }

        [HttpGet("/api/ListaPaginacaoMetodo/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var metodos = await this.IMetodo.List();

                var total = Convert.ToDouble(metodos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IMetodo.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : metodos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os metodos " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarMetodo([FromBody] Metodo Metodo)
        {
            try
            {
                if (String.IsNullOrEmpty(Metodo.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

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
        public async Task<IActionResult> EditarMetodo([FromBody] Metodo Metodo)
        {
            try
            {
                if (String.IsNullOrEmpty(Metodo.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

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
                Json(await Task.FromResult(this.IMetodo.Delete(Metodo)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o metodo " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
