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
    public class CidadeApiController : Controller
    {
        private readonly ICidade ICidade;

        public CidadeApiController(ICidade ICidade)
        {
            this.ICidade = ICidade;
        }

        [HttpGet("/api/ListaPaginacaoCidade/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var cidades = await this.ICidade.List();

                var total = Convert.ToDouble(cidades.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ICidade.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : cidades);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as cidades " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaCidade")]
        public async Task<JsonResult> ListaCidade()
        {
            try
            {
                return Json(await this.ICidade.List());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as cidades " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarCidade")]
        public async Task<IActionResult> AdicionarCidade([FromBody] Cidade Cidade)
        {
            try
            {
                if (String.IsNullOrEmpty(Cidade.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.ICidade.Add(Cidade)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a cidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaCidadePorId/{id}")]
        public async Task<JsonResult> RetornaCidadePorId(int id)
        {
            try
            {
                return Json(await this.ICidade.GetCidade(id));
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a cidade " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarCidade")]
        public async Task<IActionResult> EditarCidade([FromBody] Cidade Cidade)
        {
            try
            {
                if (String.IsNullOrEmpty(Cidade.Nome.Trim()))
                    return BadRequest("Campo de nome é obrigatório");

                Json(await Task.FromResult(this.ICidade.Update(Cidade)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar a cidade " + ex.Message }) { StatusCode = 400 };
            }
            
        }

        [HttpPost("/api/ExcluirCidade")]
        public async Task<JsonResult> ExcluirCidade([FromBody] Cidade Cidade)
        {
            try
            {
                Json(await Task.FromResult(this.ICidade.Delete(Cidade)));
                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir a cidade " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
