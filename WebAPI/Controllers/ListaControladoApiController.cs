using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class ListaControladoApiController: Controller
    {
        private readonly IListaControlado IListaControlado;

        public ListaControladoApiController(IListaControlado IListaControlado)
        {
            this.IListaControlado = IListaControlado;
        }

        [HttpGet("/api/ListaPaginacaoListaControlado/{pagina}")]
        public async Task<IActionResult> ListaPaginacao(int pagina)
        {
            try
            {
                var listaControlados = await this.IListaControlado.List();

                var total = Convert.ToDouble(listaControlados.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IListaControlado.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : listaControlados);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os listaControlados " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarListaControlado([FromBody] ListaControlado ListaControlado)
        {
            try
            {
                if (String.IsNullOrEmpty(ListaControlado.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (String.IsNullOrEmpty(ListaControlado.Codigo.Trim()))
                    return BadRequest("Campo de código é obrigatório");

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
        public async Task<IActionResult> EditarListaControlado([FromBody] ListaControlado ListaControlado)
        {
            try
            {
                if (String.IsNullOrEmpty(ListaControlado.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (String.IsNullOrEmpty(ListaControlado.Codigo.Trim()))
                    return BadRequest("Campo de código é obrigatório");

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
                Json(await Task.FromResult(this.IListaControlado.Delete(ListaControlado)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a lista de controlado " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
