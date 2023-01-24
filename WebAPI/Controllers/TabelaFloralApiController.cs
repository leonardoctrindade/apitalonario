using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class TabelaFloralApiController : Controller
    {
        private readonly ITabelaFloral ITabelaFloral;

        public TabelaFloralApiController(ITabelaFloral ITabelaFloral)
        {
            this.ITabelaFloral = ITabelaFloral;
        }

        [HttpGet("/api/ListaPaginacaoTabelaFloral/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var tabelas = await this.ITabelaFloral.List();

                var total = Convert.ToDouble(tabelas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ITabelaFloral.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : tabelas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os tabelas florais " + ex.Message }) { StatusCode = 400 };
            }
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
        public async Task<IActionResult> AdicionarTabelaFloral([FromBody] TabelaFloral TabelaFloral)
        {
            try
            {
                if (TabelaFloral.Volume <= 0)
                    return BadRequest("Campo de volume é obrigatório");
                if (TabelaFloral.QuantidadeInicial <= 0)
                    return BadRequest("Campo de quantidade inicial é obrigatório");
                if (TabelaFloral.QuantidadeFinal <= 0)
                    return BadRequest("Campo de quantidade final é obrigatório");
                if (TabelaFloral.ValorVenda <= 0)
                    return BadRequest("Campo de valor de venda é obrigatório");

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
        public async Task<IActionResult> EditarTabelaFloral([FromBody] TabelaFloral TabelaFloral)
        {
            try
            {
                if (TabelaFloral.Volume <= 0)
                    return BadRequest("Campo de volume é obrigatório");
                if (TabelaFloral.QuantidadeInicial <= 0)
                    return BadRequest("Campo de quantidade inicial é obrigatório");
                if (TabelaFloral.QuantidadeFinal <= 0)
                    return BadRequest("Campo de quantidade final é obrigatório");
                if (TabelaFloral.ValorVenda <= 0)
                    return BadRequest("Campo de valor de venda é obrigatório");

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
                Json(await Task.FromResult(this.ITabelaFloral.Delete(TabelaFloral)));
                return Json(Ok());
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
