using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class PosologiaApiController: Controller
    {
        private readonly IPosologia IPosologia;

        public PosologiaApiController(IPosologia IPosologia)
        {
            this.IPosologia = IPosologia;
        }

        [HttpGet("/api/ListaPaginacaoPosologia/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var posologias = await this.IPosologia.List();

                var total = Convert.ToDouble(posologias.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IPosologia.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : posologias);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os posologias " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaPosologia")]
        public async Task<JsonResult> ListaPosologia()
        {
            try
            {
                return Json(await this.IPosologia.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as posologias " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarPosologia")]
        public async Task<IActionResult> AdicionarPosologia([FromBody] Posologia Posologia)
        {
            try
            {
                if (string.IsNullOrEmpty(Posologia.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IPosologia.Add(Posologia)));

                return Json(Ok());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a posologia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaPosologiaPorId/{id}")]
        public async Task<JsonResult> RetornaPosologiaPorId(int id)
        {
            try
            {
                return Json(await this.IPosologia.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a posologia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPosologia")]
        public async Task<IActionResult> EditarPosologia([FromBody] Posologia Posologia)
        {
            try
            {
                if (string.IsNullOrEmpty(Posologia.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IPosologia.Update(Posologia)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a posologia " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPosologia")]
        public async Task<JsonResult> ExcluirPosologia([FromBody] Posologia Posologia)
        {
            try
            {
                Json(await Task.FromResult(this.IPosologia.Delete(Posologia)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a posologia " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
