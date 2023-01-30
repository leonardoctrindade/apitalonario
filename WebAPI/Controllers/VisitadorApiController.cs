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
    public class VisitadorApiController : Controller
    {
        private readonly IVisitador IVisitador;

        public VisitadorApiController(IVisitador iVisitador)
        {
            IVisitador = iVisitador;
        }

        [HttpGet("/api/ListaPaginacaoVisitador/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var visitadores = await this.IVisitador.List();

                var total = Convert.ToDouble(visitadores.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IVisitador.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : visitadores);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os visitadores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaVisitador")]
        public async Task<JsonResult> ListaVisitador()
        {
            try
            {
                return Json(await this.IVisitador.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os visitadores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarVisitador")]
        public async Task<IActionResult> AdicionarVisitador([FromBody] Visitador visitador)
        {
            try
            {
                if (string.IsNullOrEmpty(visitador.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IVisitador.Add(visitador)));

            }
            catch (Exception)
            {

                throw;
            }
            return Json(Ok());
        }

        [HttpGet("/api/RetornaVisitadorPorId/{id}")]
        public async Task<JsonResult> RetornarVisitadorPorId(int id)
        {
            try
            {
                return Json(await this.IVisitador.GetVisitador(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar os visitadores " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarVisitador")]
        public async Task<IActionResult> EditarVisitador([FromBody] Visitador visitador)
        {
            try
            {
                if (string.IsNullOrEmpty(visitador.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IVisitador.Update(visitador)));

            }
            catch (Exception)
            {

                throw;
            }
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirVisitador")]
        public async Task<JsonResult> ExcluirVisitador([FromBody] Visitador visitador)
        {
            try
            {
                await Task.FromResult(this.IVisitador.Delete(visitador));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir os visitadores " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
