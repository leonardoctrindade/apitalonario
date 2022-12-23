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
    public class TabelaHomeopatiaQuantidadeApiController: Controller
    {
        private readonly ITabelaHomeopatiaQuantidade ITabelaHomeopatiaQuantidade;

        public TabelaHomeopatiaQuantidadeApiController(ITabelaHomeopatiaQuantidade ITabelaHomeopatiaQuantidade)
        {
            this.ITabelaHomeopatiaQuantidade = ITabelaHomeopatiaQuantidade;
        }

        [HttpGet("/api/ListaTabelaHomeopatiaQuantidade")]
        public async Task<JsonResult> ListaTabelaHomeopatiaQuantidade()
        {
            try
            {
                return Json(await this.ITabelaHomeopatiaQuantidade.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar tabelas de homeopatia quantidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTabelaHomeopatiaQuantidade")]
        public async Task<JsonResult> AdicionarTabelaHomeopatiaQuantidade([FromBody] TabelaHomeopatiaQuantidade TabelaHomeopatiaQuantidade)
        {
            try
            {
                if (String.IsNullOrEmpty(TabelaHomeopatiaQuantidade.Metodo))
                    return Json(BadRequest(ModelState));
                if (TabelaHomeopatiaQuantidade.DinamizacaoInicial <= 0 || TabelaHomeopatiaQuantidade.DinamizacaoFinal <= 0)
                    return Json(BadRequest(ModelState));
                if (TabelaHomeopatiaQuantidade.QuantidadeInicial < 0 || TabelaHomeopatiaQuantidade.QuantidadeFinal <= 0)
                    return Json(BadRequest(ModelState));
                if (TabelaHomeopatiaQuantidade.ValorVenda < 0 || TabelaHomeopatiaQuantidade.ValorAdicional < 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITabelaHomeopatiaQuantidade.Add(TabelaHomeopatiaQuantidade)));

                return Json(Ok());
            }
            catch(Exception ex ) 
            {
                return new JsonResult(new { message = "Error ao adicionar tabela de homeopatia quantidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTabelaHomeopatiaQuantidadePorId/{id}")]
        public async Task<JsonResult> RetornaTabelaHomeopatiaQuantidadePorId(int id)
        {
            try
            {
                return Json(await this.ITabelaHomeopatiaQuantidade.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar tabela de homeopatia quantidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTabelaHomeopatiaQuantidade")]
        public async Task<JsonResult> EditarTabelaHomeopatiaQuantidade([FromBody] TabelaHomeopatiaQuantidade TabelaHomeopatiaQuantidade)
        {
            try
            {
                if (String.IsNullOrEmpty(TabelaHomeopatiaQuantidade.Metodo))
                    return Json(BadRequest(ModelState));
                if (TabelaHomeopatiaQuantidade.DinamizacaoInicial <= 0 || TabelaHomeopatiaQuantidade.DinamizacaoFinal <= 0)
                    return Json(BadRequest(ModelState));
                if (TabelaHomeopatiaQuantidade.QuantidadeInicial < 0 || TabelaHomeopatiaQuantidade.QuantidadeFinal <= 0)
                    return Json(BadRequest(ModelState));
                if (TabelaHomeopatiaQuantidade.ValorVenda < 0 || TabelaHomeopatiaQuantidade.ValorAdicional < 0)
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITabelaHomeopatiaQuantidade.Update(TabelaHomeopatiaQuantidade)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar tabela de homeopatia quantidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTabelaHomeopatiaQuantidade")]
        public async Task<JsonResult> ExcluirTabelaHomeopatiaQuantidade([FromBody] TabelaHomeopatiaQuantidade TabelaHomeopatiaQuantidade)
        {
            try
            {
                return Json(await Task.FromResult(this.ITabelaHomeopatiaQuantidade.Delete(TabelaHomeopatiaQuantidade)));
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir tabela de homeopatia quantidade " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
