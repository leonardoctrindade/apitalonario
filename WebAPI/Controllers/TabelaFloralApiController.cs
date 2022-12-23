using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class TabelaFloralApiController : Controller
    {
        private readonly ITabelaFloral ITabelaFloral;

        public TabelaFloralApiController(ITabelaFloral ITabelaFloral)
        {
            this.ITabelaFloral = ITabelaFloral;
        }

        [HttpGet("/api/ListaTabelaFloral")]
        public async Task<JsonResult> ListaTabelaFloral()
        {
            try
            {
                return Json(await this.ITabelaFloral.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as tabelas florais " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTabelaFloral")]
        public async Task<JsonResult> AdicionarTabelaFloral([FromBody] TabelaFloral TabelaFloral)
        {
            try
            {
                if (TabelaFloral.Volume <= 0 || TabelaFloral.QuantidadeInicial <= 0 || TabelaFloral.QuantidadeFinal <= 0 || TabelaFloral.ValorVenda <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITabelaFloral.Add(TabelaFloral)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a tabela floral " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTabelaFloralPorId/{id}")]
        public async Task<JsonResult> RetornaTabelaFloralPorId(int id)
        {
            try
            {
                return Json(await this.ITabelaFloral.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a tabela floral " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTabelaFloral")]
        public async Task<JsonResult> EditarTabelaFloral([FromBody] TabelaFloral TabelaFloral)
        {
            try
            {
                if (TabelaFloral.Volume <= 0 || TabelaFloral.QuantidadeInicial <= 0 || TabelaFloral.QuantidadeFinal <= 0 || TabelaFloral.ValorVenda <= 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITabelaFloral.Update(TabelaFloral)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a tabela floral " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTabelaFloral")]
        public async Task<JsonResult> ExcluirTabelaFloral([FromBody] TabelaFloral TabelaFloral)
        {
            try
            {
                return Json(await Task.FromResult(this.ITabelaFloral.Delete(TabelaFloral)));
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir a tabela floral " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarListaTabelaFloral")]
        public async Task<JsonResult> AdicionaListaTabelaFloral([FromBody] List<TabelaFloral> lista)
        {
            try
            {
                foreach (var tabela in lista)
                {
                    if (tabela.Volume <= 0 || tabela.QuantidadeInicial <= 0 || tabela.QuantidadeFinal <= 0 || tabela.ValorVenda <= 0)
                        return Json(BadRequest(ModelState));
                    Json(await Task.FromResult(this.ITabelaFloral.Add(tabela)));
                }

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicional lista de tabela floral " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarListaTabelaFloral")]
        public async Task<JsonResult> EditarListaTabelaFloral([FromBody] List<TabelaFloral> lista)
        {
            try
            {
                foreach (var tabela in lista)
                {
                    if (tabela.Volume <= 0 || tabela.QuantidadeInicial <= 0 || tabela.QuantidadeFinal <= 0 || tabela.ValorVenda <= 0)
                        return Json(BadRequest(ModelState));
                    Json(await Task.FromResult(this.ITabelaFloral.Update(tabela)));
                }

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar lista de tabela floral " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
