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
    public class SetorDiasHorasApiController : Controller
    {
        private readonly ISetorDiasHoras ISetorDiasHoras;

        public SetorDiasHorasApiController(ISetorDiasHoras ISetorDiasHoras)
        {
            this.ISetorDiasHoras = ISetorDiasHoras;
        }

        [HttpGet("/api/ListaPaginacaoSetorDiasHoras/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var setores = await this.ISetorDiasHoras.List();

                var total = Convert.ToDouble(setores.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ISetorDiasHoras.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : setores);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os setores dias horas " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaSetorDiasHoras")]
        public async Task<JsonResult> ListaSetorDiasHoras()
        {
            try
            {
                return Json(await this.ISetorDiasHoras.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os SetoresDiasHoras " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarSetorDiasHoras")]
        public async Task<IActionResult> AdicionarSetorDiasHoras([FromBody] SetorDiasHoras SetorDiasHoras)
        {
            try
            {
                if (SetorDiasHoras.DiasHorasId <= 0)
                    return BadRequest("Campo de dias/horas é obrigatório");
                if (SetorDiasHoras.SetorId <= 0)
                    return BadRequest("Campo de setor é obrigatório");

                Json(await Task.FromResult(this.ISetorDiasHoras.Add(SetorDiasHoras)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o SetorDiasHoras " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaSetorDiasHorasPorId/{id}")]
        public async Task<JsonResult> RetornaSetorDiasHorasPorId(int id)
        {
            try
            {
                return Json(await this.ISetorDiasHoras.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o SetorDiasHoras " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarSetorDiasHoras")]
        public async Task<IActionResult> EditarSetorDiasHoras([FromBody] SetorDiasHoras SetorDiasHoras)
        {
            try
            {
                if (SetorDiasHoras.DiasHorasId <= 0)
                    return BadRequest("Campo de dias/horas é obrigatório");
                if (SetorDiasHoras.SetorId <= 0)
                    return BadRequest("Campo de setor é obrigatório");

                Json(await Task.FromResult(this.ISetorDiasHoras.Update(SetorDiasHoras)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o SetorDiasHoras " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirSetorDiasHoras")]
        public async Task<JsonResult> ExcluirSetorDiasHoras([FromBody] SetorDiasHoras SetorDiasHoras)
        {
            try
            {
                Json(await Task.FromResult(this.ISetorDiasHoras.Delete(SetorDiasHoras)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o SetorDiasHoras " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
