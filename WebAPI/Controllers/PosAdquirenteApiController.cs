using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class PosAdquirenteApiController : Controller
    {
        private readonly IPosAdquirente IPosAdquirente;

        public PosAdquirenteApiController(IPosAdquirente IPosAdquirente)
        {
            this.IPosAdquirente = IPosAdquirente;
        }

        [HttpGet("/api/ListaPaginacaoPosAdquirente/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var posAdquirentes = await this.IPosAdquirente.List();

                var total = Convert.ToDouble(posAdquirentes.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IPosAdquirente.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : posAdquirentes);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os pos adquirente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaPosAdquirente")]
        public async Task<JsonResult> ListaPosAdquirente()
        {
            try
            {
                return Json(await this.IPosAdquirente.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os pos adquirentes " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarPosAdquirente")]
        public async Task<IActionResult> AdicionarPosAdquirente([FromBody] PosAdquirente PosAdquirente)
        {
            try
            {
                if (string.IsNullOrEmpty(PosAdquirente.ChaveRequisicao.Trim()))
                    return BadRequest("Campo de chave de requisição é obrigatória");

                Json(await Task.FromResult(this.IPosAdquirente.Add(PosAdquirente)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o pos adquirente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaPosAdquirentePorId/{id}")]
        public async Task<JsonResult> RetornaPosAdquirentePorId(int id)
        {
            try
            {
                return Json(await this.IPosAdquirente.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o pos adquirente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPosAdquirente")]
        public async Task<IActionResult> EditarPosAdquirente([FromBody] PosAdquirente PosAdquirente)
        {
            try
            {
                if(string.IsNullOrEmpty(PosAdquirente.ChaveRequisicao.Trim()))
                    return BadRequest("Campo de chave de requisição é obrigatória");

                Json(await Task.FromResult(this.IPosAdquirente.Update(PosAdquirente)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o pos adquirente " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPosAdquirente")]
        public async Task<JsonResult> ExcluirPosAdquirente([FromBody] PosAdquirente PosAdquirente)
        {
            try
            {
                Json(await Task.FromResult(this.IPosAdquirente.Delete(PosAdquirente)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o pos adquirente " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
