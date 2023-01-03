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
        public async Task<JsonResult> AdicionarTabelaHomeopatia([FromBody] TabelaHomeopatia TabelaHomeopatia)
        {
            try
            {
                if (String.IsNullOrEmpty(TabelaHomeopatia.Metodo))
                    return Json(BadRequest(ModelState));
                if (TabelaHomeopatia.DinamizacaoInicial <= 0 || TabelaHomeopatia.DinamizacaoFinal <= 0 || TabelaHomeopatia.Volume < 0)
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarTabelaHomeopatia([FromBody] TabelaHomeopatia TabelaHomeopatia)
        {
            try
            {
                if (String.IsNullOrEmpty(TabelaHomeopatia.Metodo))
                    return Json(BadRequest(ModelState));
                if (TabelaHomeopatia.DinamizacaoInicial <= 0 || TabelaHomeopatia.DinamizacaoFinal <= 0 || TabelaHomeopatia.Volume < 0)
                    return Json(BadRequest(ModelState));

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
