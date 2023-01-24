using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Data.Repositorio;

namespace WebAPI.Controllers
{
    public class DciApiController : Controller
    {
        private readonly IDci IDci;
        
        public DciApiController(IDci idci)
        {
            IDci = idci;
        }

        [HttpGet("/api/ListaPaginacaoDci/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var dcis = await this.IDci.List();

                var total = Convert.ToDouble(dcis.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IDci.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : dcis);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os dcis " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaDci")]
        public async Task<JsonResult> ListaDci()
        {
            try
            {
                return Json(await this.IDci.List());
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os dci " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarDci")]
        public async Task<IActionResult> AdicionarDci([FromBody] Dci dci)
        {
            try
            {
                if (string.IsNullOrEmpty(dci.CodigoDci.Trim()))
                    return BadRequest("Campo de código Dci é obrigatório");
                if (string.IsNullOrEmpty(dci.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IDci.Add(dci)));

                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o dci " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarPorId/{id}")]
        public async Task<JsonResult> RetornarPorId(int id)
        {
            try
            {
                return Json(await this.IDci.GetEntityById(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o dci " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarDci")]
        public async Task<IActionResult> EditarDci([FromBody] Dci dci)
        {
            try
            {
                if (string.IsNullOrEmpty(dci.CodigoDci.Trim()))
                    return BadRequest("Campo de código Dci é obrigatório");
                if (string.IsNullOrEmpty(dci.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IDci.Update(dci)));

                return Json(Ok());
            } catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o dci " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirDci")]
        public async Task<JsonResult> ExcluirDci([FromBody] Dci dci)
        {
            try
            {
                Json(await Task.FromResult(this.IDci.Delete(dci)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o dci " + ex.Message }) { StatusCode = 400 };
            }

        }
    }
}
