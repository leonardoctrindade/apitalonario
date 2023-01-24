using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class EnsaioApiController : Controller
    {
        private readonly IEnsaio IEnsaio;

        public EnsaioApiController(IEnsaio IEnsaio)
        {
            this.IEnsaio = IEnsaio;
        }


        [HttpGet("/api/ListaPaginacaoEnsaio/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var ensaios = await this.IEnsaio.List();

                var total = Convert.ToDouble(ensaios.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IEnsaio.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : ensaios);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os ensaios " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaEnsaio")]
        public async Task<JsonResult> ListaEnsaio()
        {
            try
            {
                return Json(await this.IEnsaio.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os ensaios " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEnsaio")]
        public async Task<IActionResult> AdicionarEnsaio([FromBody] Ensaio Ensaio)
        {
            try
            {
                if (String.IsNullOrEmpty(Ensaio.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IEnsaio.Add(Ensaio)));

                return Json(Ok());
            } 
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaEnsaioPorId/{id}")]
        public async Task<JsonResult> RetornaEnsaioPorId(int id)
        {
            try
            {
                return Json(await this.IEnsaio.GetEnsaio(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEnsaio")]
        public async Task<IActionResult> EditarEnsaio([FromBody] Ensaio Ensaio)
        {
            try
            {
                if (String.IsNullOrEmpty(Ensaio.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.IEnsaio.Update(Ensaio)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEnsaio")]
        public async Task<JsonResult> ExcluirEnsaio([FromBody] Ensaio Ensaio)
        {
            try 
            {
                Json(await Task.FromResult(this.IEnsaio.Delete(Ensaio)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o ensaio " + ex.Message }) { StatusCode = 400 };
            }  
        }
    }
}
