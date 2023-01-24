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
    public class EtapaApiController : Controller
    {
        private readonly IEtapa IEtapa;

        public EtapaApiController(IEtapa iEtapa)
        {
            IEtapa = iEtapa;
        }

        [HttpGet("/api/ListaPaginacaoEtapa/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var etapas = await this.IEtapa.List();

                var total = Convert.ToDouble(etapas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IEtapa.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : etapas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as etapas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaEtapa")]
        public async Task<JsonResult> ListaEtapa()
        {
            try
            {
                return Json(await this.IEtapa.List());
            }
            catch (Exception)
            {

                return Json(BadRequest(ModelState));
            }
        }

        [HttpPost("/api/AdicionarEtapa")]
        public async Task<IActionResult> AdicionarEtapa([FromBody] Etapa etapa)
        {
            try
            {
                if (string.IsNullOrEmpty(etapa.Descricao.Trim()))
                    return BadRequest("Campo de descricao é obrigatório");
                if (etapa.Sequencia <= 0)
                    return BadRequest("Campo de sequencia é obrigatório");
                if (string.IsNullOrEmpty(etapa.Tipo.Trim()))
                    return BadRequest("Campo de tipo é obrigatório");

                Json(await Task.FromResult(this.IEtapa.Add(etapa)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a etapa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarEtapaPorId/{id}")]
        public async Task<JsonResult> RetornarEtapaPorId(int id)
        {
            try
            {
                return Json(await this.IEtapa.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a etapa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEtapa")]
        public async Task<IActionResult> EditarEtapa([FromBody] Etapa etapa)
        {
            try
            {
                if (string.IsNullOrEmpty(etapa.Descricao.Trim()))
                    return BadRequest("Campo de descricao é obrigatório");
                if (etapa.Sequencia <= 0)
                    return BadRequest("Campo de sequencia é obrigatório");
                if (string.IsNullOrEmpty(etapa.Tipo.Trim()))
                    return BadRequest("Campo de tipo é obrigatório");

                Json(await Task.FromResult(this.IEtapa.Update(etapa)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a etapa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEtapa")]
        public async Task<JsonResult> ExcluirEtapa([FromBody] Etapa etapa)
        {
            try
            {
                Json(await Task.FromResult(this.IEtapa.Delete(etapa)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a etapa " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
