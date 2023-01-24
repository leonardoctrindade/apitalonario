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
    public class EntregadorRegiaoApiController : Controller
    {
        private readonly IEntregadorRegiao IEntregadorRegiao;

        public EntregadorRegiaoApiController(IEntregadorRegiao IEntregadorRegiao)
        {
            this.IEntregadorRegiao = IEntregadorRegiao;
        }

        [HttpGet("/api/ListaPaginacaoEntregadorRegiao/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var entregadoresRegiao = await this.IEntregadorRegiao.List();

                var total = Convert.ToDouble(entregadoresRegiao.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IEntregadorRegiao.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : entregadoresRegiao);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os entregadores região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaEntregadorRegiao")]
        public async Task<JsonResult> ListaEntregadorRegiao()
        {
            try
            {
                return Json(await this.IEntregadorRegiao.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os entregadores da região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarEntregadorRegiao")]
        public async Task<IActionResult> AdicionarEntregadorRegiao([FromBody] EntregadorRegiao EntregadorRegiao)
        {
            try
            {
                if (EntregadorRegiao.EntregadorId == 0)
                    return BadRequest("Campo de entregador é obrigatório");
                if (EntregadorRegiao.RegiaoId == 0)
                    return BadRequest("Campo de regiao é obrigatório");

                Json(await Task.FromResult(this.IEntregadorRegiao.Add(EntregadorRegiao)));

                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o entregador da região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaEntregadorRegiaoPorId/{id}")]
        public async Task<JsonResult> RetornaEntregadorRegiaoPorId(int id)
        {
            try
            {
                return Json(await this.IEntregadorRegiao.GetEntregadorRegiao(id));
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao retornar o entregador da região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarEntregadorRegiao")]
        public async Task<IActionResult> EditarEntregadorRegiao([FromBody] EntregadorRegiao EntregadorRegiao)
        {
            try
            {
                if (EntregadorRegiao.EntregadorId == 0)
                    return BadRequest("Campo de entregador é obrigatório");
                if (EntregadorRegiao.RegiaoId == 0)
                    return BadRequest("Campo de regiao é obrigatório");

                Json(await Task.FromResult(this.IEntregadorRegiao.Update(EntregadorRegiao)));
                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao editar o entregador da região " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirEntregadorRegiao")]
        public async Task<JsonResult> ExcluirEntregadorRegiao([FromBody] EntregadorRegiao EntregadorRegiao)
        {
            try
            {
                Json(await Task.FromResult(this.IEntregadorRegiao.Delete(EntregadorRegiao)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o entregador da região " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
