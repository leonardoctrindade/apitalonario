using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers

{
    public class PortadorApiController : Controller
    {
        private readonly IPortador IPortador;

        public PortadorApiController(IPortador IPortador)
        {
            this.IPortador = IPortador;
        }

        [HttpGet("/api/ListaPaginacaoPortador/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var portadores = await this.IPortador.List();

                var total = Convert.ToDouble(portadores.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IPortador.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : portadores);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os portadores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaPortador")]
        public async Task<JsonResult> ListaPortador()
        {
            try
            {
                return Json(await this.IPortador.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os portadores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarPortador")]
        public async Task<IActionResult> AdicionarPortador([FromBody] Portador Portador)
        {
            try
            {
                if (string.IsNullOrEmpty(Portador.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IPortador.Add(Portador)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o portador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaPortadorPorId/{id}")]
        public async Task<JsonResult> RetornaPortadorPorId(int id)
        {
            try
            {
                return Json(await this.IPortador.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o portador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPortador")]
        public async Task<IActionResult> EditarPortador([FromBody] Portador Portador)
        {
            try
            {
                if (string.IsNullOrEmpty(Portador.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IPortador.Update(Portador)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o portador " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPortador")]
        public async Task<JsonResult> ExcluirPortador([FromBody] Portador Portador)
        {
            try
            {
                Json(await Task.FromResult(this.IPortador.Delete(Portador)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o portador " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
