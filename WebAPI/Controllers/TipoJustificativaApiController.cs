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
    public class TipoJustificativaApiController : Controller
    {
        private readonly ITipoJustificativa ITipoJustificativa;

        public TipoJustificativaApiController(ITipoJustificativa itipoJustificativa)
        {
            this.ITipoJustificativa = itipoJustificativa;
        }

        [HttpGet("/api/ListaPaginacaoTipoJustificativa/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var tipoJustificativas = await this.ITipoJustificativa.List();

                var total = Convert.ToDouble(tipoJustificativas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ITipoJustificativa.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : tipoJustificativas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os tipos de justificativas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaTipoJustificativa")]
        public async Task<JsonResult> ListaTipoJustificativa()
        {
            try
            {
                return Json(await this.ITipoJustificativa.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os tipos de justificativa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTipoJustificativa")]
        public async Task<IActionResult> AdicionarTipoJustificativa([FromBody] TipoJustificativa tipoJustificativa)
        { 
            try
            {
                if (string.IsNullOrEmpty(tipoJustificativa.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                return Json(await Task.FromResult(this.ITipoJustificativa.Add(tipoJustificativa)));
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
        }

        [HttpGet("/api/RetornarTipoJustificativaPorId/{id}")]
        public async Task<JsonResult> RetornarTipoJustificativaPorId(int id)
        {
            try
            {
                return Json(await this.ITipoJustificativa.GetEntityById(id));
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar o tipo de justificativa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTipoJustificativa")]
        public async Task<IActionResult> EditarTipoJustificativa([FromBody] TipoJustificativa tipoJustificativa)
        {
            try
            {
                if (string.IsNullOrEmpty(tipoJustificativa.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                return Json(await Task.FromResult(this.ITipoJustificativa.Update(tipoJustificativa)));
            }
            catch (Exception)
            {
                return Json(BadRequest(ModelState));
            }
        }

        [HttpPost("/api/ExcluiTipoJustificativa")]
        public async Task<JsonResult> ExcluiTipoJustificativa([FromBody] TipoJustificativa tipoJustificativa)
        {
            try
            {
                Json(await Task.FromResult(this.ITipoJustificativa.Delete(tipoJustificativa)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o tipo de justificativa " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
