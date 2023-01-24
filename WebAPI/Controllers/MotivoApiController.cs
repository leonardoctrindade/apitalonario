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
    public class MotivoApiController : Controller
    {
        private readonly IMotivo IMotivo;

        public MotivoApiController(IMotivo imotivo)
        {
            IMotivo = imotivo;
        }

        [HttpGet("/api/ListaPaginacaoMotivo/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var motivos = await this.IMotivo.List();

                var total = Convert.ToDouble(motivos.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IMotivo.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : motivos);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os motivos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaMotivo")]
        public async Task<JsonResult> ListaMotivo()
        {
            try
            {
                return Json(await this.IMotivo.List());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao listar os motivos " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarMotivo")]
        public async Task<IActionResult> AdicionarMotivo([FromBody] Motivo motivo)
        {
            try
            {
                if (string.IsNullOrEmpty(motivo.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IMotivo.Add(motivo)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o motivo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarMotivoPorId/{id}")]
        public async Task<JsonResult> RetornarMotivoPorId(int id)
        {
            try
            {
                if (id == 0)
                    return Json(BadRequest(ModelState));

                return Json(await this.IMotivo.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o motivo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarMotivo")]
        public async Task<IActionResult> EditarMotivo([FromBody] Motivo motivo)
        {
            try
            {
                if (string.IsNullOrEmpty(motivo.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.IMotivo.Update(motivo)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o motivo " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirMotivo")]
        public async Task<JsonResult> ExcluirMotivo([FromBody] Motivo motivo)
        {
            try
            {
                Json(await Task.FromResult(this.IMotivo.Delete(motivo)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o motivo " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
