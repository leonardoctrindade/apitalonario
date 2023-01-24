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
    public class TributoApiController : Controller
    {
        private readonly ITributo ITributo;

        public TributoApiController(ITributo ITributo)
        {
            this.ITributo = ITributo;
        }

        [HttpGet("/api/ListaPaginacaoTributo/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var tributos = await this.ITributo.List();

                var total = Convert.ToDouble(tributos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ITributo.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : tributos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os tributos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaTributo")]
        public async Task<JsonResult> ListaTributo()
        {
            try
            {
                return Json(await this.ITributo.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os tributos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTributo")]
        public async Task<IActionResult> AdicionarTributo([FromBody] Tributo Tributo)
        {
            try
            {
                if (string.IsNullOrEmpty(Tributo.Codigo.Trim()))
                    return BadRequest("Campo de código é obrigatório");
                if (string.IsNullOrEmpty(Tributo.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.ITributo.Add(Tributo)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o tributo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTributoPorId/{id}")]
        public async Task<JsonResult> RetornaTributoPorId(int id)
        {
            try
            {
                return Json(await this.ITributo.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o tributo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTributo")]
        public async Task<IActionResult> EditarTributo([FromBody] Tributo Tributo)
        {
            try
            {
                if (string.IsNullOrEmpty(Tributo.Codigo.Trim()))
                    return BadRequest("Campo de código é obrigatório");
                if (string.IsNullOrEmpty(Tributo.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.ITributo.Update(Tributo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o tributo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTributo")]
        public async Task<JsonResult> ExcluirTributo([FromBody] Tributo Tributo)
        {
            try
            {
                Json(await Task.FromResult(this.ITributo.Delete(Tributo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o tributo " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
