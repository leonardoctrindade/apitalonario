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
    public class TabelaHomeopatiaApiController: Controller
    {
        private readonly ITabelaHomeopatia ITabelaHomeopatia;

        public TabelaHomeopatiaApiController(ITabelaHomeopatia ITabelaHomeopatia)
        {
            this.ITabelaHomeopatia = ITabelaHomeopatia;
        }

        [HttpGet("/api/ListaPaginacaoTabelaHomeopatia/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var tabelas = await this.ITabelaHomeopatia.List();

                var total = Convert.ToDouble(tabelas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ITabelaHomeopatia.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : tabelas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os tabelas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaTabelaHomeopatia")]
        public async Task<JsonResult> ListaTabelaHomeopatia()
        {
            try
            {
                return Json(await this.ITabelaHomeopatia.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as tabela de homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTabelaHomeopatia")]
        public async Task<IActionResult> AdicionarTabelaHomeopatia([FromBody] TabelaHomeopatia TabelaHomeopatia)
        {
            try
            {
                if (string.IsNullOrEmpty(TabelaHomeopatia.Metodo.Trim()))
                    return BadRequest("Campo de método é obrigatório");

                Json(await Task.FromResult(this.ITabelaHomeopatia.Add(TabelaHomeopatia)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a tabela de homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTabelaHomeopatiaPorId/{id}")]
        public async Task<JsonResult> RetornaTabelaHomeopatiaPorId(int id)
        {
            try
            {
                return Json(await this.ITabelaHomeopatia.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a tabela de homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTabelaHomeopatia")]
        public async Task<IActionResult> EditarTabelaHomeopatia([FromBody] TabelaHomeopatia TabelaHomeopatia)
        {
            try
            {
                if (string.IsNullOrEmpty(TabelaHomeopatia.Metodo.Trim()))
                    return BadRequest("Campo de método é obrigatório");

                Json(await Task.FromResult(this.ITabelaHomeopatia.Update(TabelaHomeopatia)));
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar a tabela de homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTabelaHomeopatia")]
        public async Task<JsonResult> ExcluirTabelaHomeopatia([FromBody] TabelaHomeopatia TabelaHomeopatia)
        {
            try
            {
                Json(await Task.FromResult(this.ITabelaHomeopatia.Delete(TabelaHomeopatia)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a tabela de homeopatia " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
