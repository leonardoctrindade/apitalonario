using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class BulaApiController : Controller
    {
        private readonly IBula IBula;

        public BulaApiController(IBula IBula)
        {
            this.IBula = IBula;
        }

        [HttpGet("/api/ListaPaginacaoBula/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var bulas = await this.IBula.List();

                var total = Convert.ToDouble(bulas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IBula.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : bulas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as bulas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaBula")]
        public async Task<JsonResult> ListaBula()
        {
            try
            {
                return Json(await this.IBula.List());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as bulas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarBula")]
        public async Task<IActionResult> AdicionarBula([FromBody] Bula Bula)
        {
            try
            {
                if (String.IsNullOrEmpty(Bula.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (Bula.Tipo != 1 && Bula.Tipo != 2)
                    return BadRequest("Campo de tipo é obrigatório");

                Json(await Task.FromResult(this.IBula.Add(Bula)));

                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a bula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaBulaPorId/{id}")]
        public async Task<JsonResult> RetornaBulaPorId(int id)
        {
            try
            {
                return Json(await this.IBula.GetEntityById(id));
            } catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a bula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarBula")]
        public async Task<IActionResult> EditarBula([FromBody] Bula Bula)
        {
            try
            {
                if (String.IsNullOrEmpty(Bula.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (Bula.Tipo != 1 && Bula.Tipo != 2)
                    return BadRequest("Campo de tipo é obrigatório");

                Json(await Task.FromResult(this.IBula.Update(Bula)));
                return Json(Ok());
            } catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar a bula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirBula")]
        public async Task<JsonResult> ExcluirBula([FromBody] Bula Bula)
        {
            try
            {
                Json(await Task.FromResult(this.IBula.Delete(Bula)));
                return Json(Ok());
            } catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao excluir a bula " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
