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
    public class DiasHorasApiController : Controller
    {
        private readonly IDiasHoras IDiasHoras;

        public DiasHorasApiController(IDiasHoras IDiasHoras)
        {
            this.IDiasHoras = IDiasHoras;
        }

        [HttpGet("/api/ListaPaginacaoDiasHoras/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var diashoras = await this.IDiasHoras.List();

                var total = Convert.ToDouble(diashoras.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IDiasHoras.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : diashoras);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os dias/horas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaDiasHoras")]
        public async Task<JsonResult> ListaDiasHoras()
        {
            try
            {
                return Json(await this.IDiasHoras.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os dias/horas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarDiasHoras")]
        public async Task<IActionResult> AdicionarDiasHoras([FromBody] DiasHoras DiasHoras)
        {
            try
            {
                if (DiasHoras.CodigoDia <= 0)
                    return BadRequest("Campo de código dia é obrigatório");
                if (DiasHoras.Sequencia <= 0)
                    return BadRequest("Campo de sequencia é obrigatório");

                Json(await Task.FromResult(this.IDiasHoras.Add(DiasHoras)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o dia/hora " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaDiasHorasPorId/{id}")]
        public async Task<JsonResult> RetornaDiasHorasPorId(int id)
        {
            try
            {
                return Json(await this.IDiasHoras.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o dia/hora " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarDiasHoras")]
        public async Task<IActionResult> EditarDiasHoras([FromBody] DiasHoras DiasHoras)
        {
            try
            {
                if (DiasHoras.CodigoDia <= 0)
                    return BadRequest("Campo de código dia é obrigatório");
                if (DiasHoras.Sequencia <= 0)
                    return BadRequest("Campo de sequencia é obrigatório");

                Json(await Task.FromResult(this.IDiasHoras.Update(DiasHoras)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o dia/hora" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirDiasHoras")]
        public async Task<JsonResult> ExcluirDiasHoras([FromBody] DiasHoras DiasHoras)
        {
            try
            {
                Json(await Task.FromResult(this.IDiasHoras.Delete(DiasHoras)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o dia/hora " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
