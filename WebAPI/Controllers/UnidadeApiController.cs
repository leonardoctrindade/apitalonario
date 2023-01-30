using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;

namespace WebAPI.Controllers
{
    public class UnidadeApiController : Controller
    {
        private readonly IUnidade IUnidade;

        public UnidadeApiController(IUnidade iunidade)
        {
            this.IUnidade = iunidade;
        }

        [HttpGet("/api/ListaPaginacaoUnidade/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var unidades = await this.IUnidade.List();

                var total = Convert.ToDouble(unidades.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IUnidade.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : unidades);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os unidades " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaUnidade")]
        public async Task<JsonResult> ListaUnidade()
        {
            try
            {
                return Json(await this.IUnidade.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as unidades " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarUnidade")]
        public async Task<IActionResult> AdicionarUnidade([FromBody] Unidade unidade)
        {
            try
            {
                if (string.IsNullOrEmpty(unidade.Sigla.Trim()))
                    return BadRequest("Campo de sigla é obrigatório");
                if (string.IsNullOrEmpty(unidade.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IUnidade.Add(unidade)));
                
                return Json(Ok());
            }
            catch (Exception)
            {

                return Json(BadRequest(ModelState));
            }
        }

        [HttpGet("/api/RetornaUnidadePorId/{id}")]
        public async Task<JsonResult> RetornarUnidadeProId(int id)
        {
            try
            {
                if (id == 0)
                    return Json(BadRequest(ModelState));

                return Json(await this.IUnidade.GetUnidade(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a unidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarUnidade")]
        public async Task<IActionResult> EditarUnidade([FromBody] Unidade unidade)
        {
            try
            {
                if (string.IsNullOrEmpty(unidade.Sigla.Trim()))
                    return BadRequest("Campo de sigla é obrigatório");
                if (string.IsNullOrEmpty(unidade.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IUnidade.Update(unidade)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a unidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirUnidade")]
        public async Task<JsonResult> ExcluirUnidade([FromBody] Unidade unidade)
        {
            try
            {
                var teste = await this.IUnidade.GetUnidade(unidade.Id);
                await Task.FromResult(this.IUnidade.Delete(teste));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a unidade " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
