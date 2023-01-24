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
    public class FidelidadePremiosApiController: Controller
    {
        private readonly IFidelidadePremios IFidelidadePremios;

        public FidelidadePremiosApiController(IFidelidadePremios IFidelidadePremios)
        {
            this.IFidelidadePremios = IFidelidadePremios;
        }

        [HttpGet("/api/ListaPaginacaoFidelidadePremios/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var fidelidadePremios = await this.IFidelidadePremios.List();

                var total = Convert.ToDouble(fidelidadePremios.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IFidelidadePremios.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : fidelidadePremios);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as fidelidades premios " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaFidelidadePremios")]
        public async Task<JsonResult> ListaFidelidadePremios()
        {
            try
            {
                return Json(await this.IFidelidadePremios.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os premios de fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFidelidadePremios")]
        public async Task<IActionResult> AdicionarFidelidadePremios([FromBody] FidelidadePremios FidelidadePremios)
        {
            try
            {
                if (FidelidadePremios.FidelidadeId == 0)
                    return BadRequest("Campo de fidelidade é obrigatório");
                if (FidelidadePremios.GrupoId == 0)
                    return BadRequest("Campo de grupo é obrigatório");
                if (FidelidadePremios.ProdutoId == 0)
                    return BadRequest("Campo de produto é obrigatório");
                if (FidelidadePremios.Pontos < 0)
                    return BadRequest("Campo de pontos é obrigatório");

                Json(await Task.FromResult(this.IFidelidadePremios.Add(FidelidadePremios)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o premio de fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFidelidadePremiosPorId/{id}")]
        public async Task<JsonResult> RetornaFidelidadePremiosPorId(int id)
        {
            try
            {
                return Json(await this.IFidelidadePremios.GetFidelidadePremios(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o premio de fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFidelidadePremios")]
        public async Task<IActionResult> EditarFidelidadePremios([FromBody] FidelidadePremios FidelidadePremios)
        {
            try
            {
                if (FidelidadePremios.FidelidadeId == 0)
                    return BadRequest("Campo de fidelidade é obrigatório");
                if (FidelidadePremios.GrupoId == 0)
                    return BadRequest("Campo de grupo é obrigatório");
                if (FidelidadePremios.ProdutoId == 0)
                    return BadRequest("Campo de produto é obrigatório");
                if (FidelidadePremios.Pontos < 0)
                    return BadRequest("Campo de pontos é obrigatório");

                Json(await Task.FromResult(this.IFidelidadePremios.Update(FidelidadePremios)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o premio de fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFidelidadePremios")]
        public async Task<JsonResult> ExcluirFidelidadePremios([FromBody] FidelidadePremios FidelidadePremios)
        {
            try
            {
                Json(await Task.FromResult(this.IFidelidadePremios.Delete(FidelidadePremios)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o premio de fidelidade " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
