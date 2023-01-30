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
    public class ContabilistaApiController : Controller
    {
        private readonly IContabilista IContabilista;

        public ContabilistaApiController(IContabilista icontabilista)
        {
            IContabilista = icontabilista;
        }

        [HttpGet("/api/ListaPaginacaoContabilista/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var contabilistas = await this.IContabilista.List();

                var total = Convert.ToDouble(contabilistas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IContabilista.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : contabilistas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os contabilistas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaContabilista")]
        public async Task<JsonResult> ListaContabilista()
        {
            try
            {
                return Json(await this.IContabilista.List());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os contabilistas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarContabilista")]
        public async Task<IActionResult> AdicionarContabilista([FromBody] Contabilista contabilista)
        {
            try
            {
                if (string.IsNullOrEmpty(contabilista.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");
                if (string.IsNullOrEmpty(contabilista.Cpf.Trim()))
                    return BadRequest("Campo de cpf é obrigatório");
                if (string.IsNullOrEmpty(contabilista.Cnpj.Trim()))
                    return BadRequest("Campo de cnpj é obrigatorio");
                if (string.IsNullOrEmpty(contabilista.Crc.Trim()))
                    return BadRequest("Campo de Crc é obrigatorio");

                Json(await Task.FromResult(this.IContabilista.Add(contabilista)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o contabilista " + ex.Message }) { StatusCode = 400 };
            }
            
        }

        [HttpGet("/api/RetornaContabilistaPorId/{id}")]
        public async Task<JsonResult> RetornarContabilistaPorId(int id)
        {
            try
            {
                return Json(await this.IContabilista.GetContabilista(id));
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar o contabilista " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarContabilista")]
        public async Task<IActionResult> EditarContabilista([FromBody] Contabilista contabilista)
        {
            try
            {
                if (string.IsNullOrEmpty(contabilista.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");
                if (string.IsNullOrEmpty(contabilista.Cpf.Trim()))
                    return BadRequest("Campo de cpf é obrigatório");
                if (string.IsNullOrEmpty(contabilista.Cnpj.Trim()))
                    return BadRequest("Campo de cnpj é obrigatorio");
                if (string.IsNullOrEmpty(contabilista.Crc.Trim()))
                    return BadRequest("Campo de Crc é obrigatorio");

                Json(await Task.FromResult(this.IContabilista.Update(contabilista)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o contabilista " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirContabilista")]
        public async Task<JsonResult> ExcluirContabilista([FromBody] Contabilista contabilista)
        {
            try
            {
                Json(await Task.FromResult(this.IContabilista.Delete(contabilista)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir o contabilista " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
