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
    public class UnidadeConversaoApiController : Controller
    {
        private readonly IUnidadeConversao IUnidadeConversao;

        public UnidadeConversaoApiController(IUnidadeConversao iUnidadeConversao)
        {
            IUnidadeConversao = iUnidadeConversao;
        }

        [HttpGet("/api/ListaPaginacaoUnidadeConversao/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var unidades = await this.IUnidadeConversao.List();

                var total = Convert.ToDouble(unidades.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IUnidadeConversao.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : unidades);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os unidades de conversão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaUnidadeConversao")]
        public async Task<JsonResult> ListaUnidadeConversao()
        {
            try
            {
                return Json(await this.IUnidadeConversao.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as unidades de conversão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarUnidadeConversao")]
        public async Task<IActionResult> AdicionarUnidadeConversao([FromBody] UnidadeConversao unidadeConversao)
        {
            try
            {
                if (string.IsNullOrEmpty(unidadeConversao.Sigla.Trim()))
                    return BadRequest("Campo de sigla é obrigatório");
                if (string.IsNullOrEmpty(unidadeConversao.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IUnidadeConversao.Add(unidadeConversao)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a unidade de conversão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarUnidadeConversaoPorId/{id}")]
        public async Task<JsonResult> RetornarUnidadeConversaoPorId(int id)
        {
            try
            {
                return Json(await this.IUnidadeConversao.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a unidade de conversão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarUnidadeConversao")]
        public async Task<IActionResult> EditarUnidadeConversao([FromBody] UnidadeConversao unidadeConversao)
        {
            try
            {
                if (string.IsNullOrEmpty(unidadeConversao.Sigla.Trim()))
                    return BadRequest("Campo de sigla é obrigatório");
                if (string.IsNullOrEmpty(unidadeConversao.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IUnidadeConversao.Update(unidadeConversao)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar a unidade de conversão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirUnidadeConversao")]
        public async Task<JsonResult> ExcluirUnidadeConversao([FromBody] UnidadeConversao unidadeConversao)
        {
            try
            {
                return Json(await Task.FromResult(this.IUnidadeConversao.Delete(unidadeConversao)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a unidade de conversão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarConversaoVinculada/{id}")]
        public async Task<JsonResult> RetornarConversaoVinculada(int id)
        {
            try
            {
                var Unidades = new List<UnidadeConversao>();
                var unidades = await this.IUnidadeConversao.List();

                foreach (var x in unidades)
                {
                    if (x.UnidadeId == id)
                        Unidades.Add(x);
                }
                return Json(Unidades);
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar conversão vinculada a unidade de conversão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarListaUnidades")]
        public async Task<JsonResult> AdicionarListaUnidades([FromBody] List<UnidadeConversao> unidadeConversaos)
        {
            try
            {
                foreach (var x in unidadeConversaos)
                {
                    Json(await Task.FromResult(this.IUnidadeConversao.Add(x)));
                }
                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar lista de unidades de conversão " + ex.Message }) { StatusCode = 400 };
            }
        }  
    }
}


