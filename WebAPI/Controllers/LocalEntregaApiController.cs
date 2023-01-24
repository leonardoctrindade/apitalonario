using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class LocalEntregaApiController : Controller
    {
        private readonly ILocalEntrega ILocalEntrega;

        public LocalEntregaApiController(ILocalEntrega ILocalEntrega)
        {
            this.ILocalEntrega = ILocalEntrega;
        }

        [HttpGet("/api/ListaPaginacaoLocalEntrega/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var localEntregas = await this.ILocalEntrega.List();

                var total = Convert.ToDouble(localEntregas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ILocalEntrega.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : localEntregas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os locais de entregas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaLocalEntrega")]
        public async Task<JsonResult> ListaLocalEntrega()
        {
            try
            {
                return Json(await this.ILocalEntrega.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os locais de entrega " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarLocalEntrega")]
        public async Task<IActionResult> AdicionarLocalEntrega([FromBody] LocalEntrega LocalEntrega)
        {
            try
            {
                if (String.IsNullOrEmpty(LocalEntrega.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (LocalEntrega.TaxaEntrega <= 0)
                    return BadRequest("Campo de taxa de entrega é obrigatório");

                Json(await Task.FromResult(this.ILocalEntrega.Add(LocalEntrega)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o local de entrega " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaLocalEntregaPorId/{id}")]
        public async Task<JsonResult> RetornaLocalEntregaPorId(int id)
        {
            try
            {
                return Json(await this.ILocalEntrega.GetLocalEntrega(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o local de entrega " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarLocalEntrega")]
        public async Task<IActionResult> EditarLocalEntrega([FromBody] LocalEntrega LocalEntrega)
        {
            try
            {
                if (String.IsNullOrEmpty(LocalEntrega.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");
                if (LocalEntrega.TaxaEntrega <= 0)
                    return BadRequest("Campo de taxa de entrega é obrigatório");

                Json(await Task.FromResult(this.ILocalEntrega.Update(LocalEntrega)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o local de entrega " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirLocalEntrega")]
        public async Task<JsonResult> ExcluirLocalEntrega([FromBody] LocalEntrega LocalEntrega)
        {
            try
            {
                Json(await Task.FromResult(this.ILocalEntrega.Delete(LocalEntrega)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o local de entrega " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
