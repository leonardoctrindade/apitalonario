using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    public class MaquinaPosApiController : Controller
    {
        private readonly IMaquinaPos IMaquinaPos;

        public MaquinaPosApiController(IMaquinaPos IMaquinaPos)
        {
            this.IMaquinaPos = IMaquinaPos;
        }

        [HttpGet("/api/ListaPaginacaoMaquinaPos/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var maquinasPos = await this.IMaquinaPos.List();

                var total = Convert.ToDouble(maquinasPos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IMaquinaPos.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : maquinasPos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as maquinas pos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaMaquinaPos")]
        public async Task<JsonResult> ListaMaquinaPos()
        {
            try
            {
                return Json(await this.IMaquinaPos.List());
            }
            catch (Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar as maquinas pos" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarMaquinaPos")]
        public async Task<IActionResult> AdicionarMaquinaPos([FromBody] MaquinaPos MaquinaPos)
        {
            try
            {
                if (String.IsNullOrEmpty(MaquinaPos.SerialPos.Trim()))
                    return BadRequest("Campo de serial pos é obrigatório");

                Json(await Task.FromResult(this.IMaquinaPos.Add(MaquinaPos)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar a maquina pos" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaMaquinaPosPorId/{id}")]
        public async Task<JsonResult> RetornaMaquinaPosPorId(int id)
        {
            try
            {
                return Json(await this.IMaquinaPos.GetMaquinaPos(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a maquina pos" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarMaquinaPos")]
        public async Task<IActionResult> EditarMaquinaPos([FromBody] MaquinaPos MaquinaPos)
        {
            try
            {
                if (String.IsNullOrEmpty(MaquinaPos.SerialPos.Trim()))
                    return BadRequest("Campo de serial pos é obrigatório");

                Json(await Task.FromResult(this.IMaquinaPos.Update(MaquinaPos)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a maquina pos" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirMaquinaPos")]
        public async Task<JsonResult> ExcluirMaquinaPos([FromBody] MaquinaPos MaquinaPos)
        {
            try
            {
                Json(await Task.FromResult(this.IMaquinaPos.Delete(MaquinaPos)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a maquina pos" + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
