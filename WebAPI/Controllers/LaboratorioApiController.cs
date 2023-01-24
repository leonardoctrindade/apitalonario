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
    public class LaboratorioApiController : Controller
    {
        private readonly ILaboratorio ILaboratorio;

        public LaboratorioApiController(ILaboratorio ilaboratorio)
        {
            this.ILaboratorio = ilaboratorio;
        }

        [HttpGet("/api/ListaPaginacaoLaboratorio/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var laboratorios = await this.ILaboratorio.List();

                var total = Convert.ToDouble(laboratorios.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.ILaboratorio.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : laboratorios);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os laboratorios " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaLaboratorio")]
        public async Task<JsonResult> ListaLaboratorio()
        {
            try
            {
                return Json(await this.ILaboratorio.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os laboratorios " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarLaboratorio")]
        public async Task<IActionResult> AdicionarLaboratorio([FromBody] Laboratorio laboratorio)
        {
            try
            {
                if (string.IsNullOrEmpty(laboratorio.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.ILaboratorio.Add(laboratorio)));

                return Json(Ok());
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { message = "Error ao adicionar o laboratorio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornarLaboratorioId/{id}")]
        public async Task<JsonResult> RetornarLaboratorioId(int id)
        {
            try
            {
                if (id <= 0)
                    return Json(BadRequest(ModelState));

                return Json(await this.ILaboratorio.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o laboratorio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarLaboratorio")]
        public async Task<IActionResult> EditarLaboratorio([FromBody] Laboratorio laboratorio)
        {
            try
            {
                if (string.IsNullOrEmpty(laboratorio.Descricao.Trim()))
                    return BadRequest("Campo de descrição é obrigatório");

                Json(await Task.FromResult(this.ILaboratorio.Update(laboratorio)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o laboratorio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirLaboratorio")]
        public async Task<JsonResult> ExcluirLaboratorio([FromBody] Laboratorio laboratorio)
        {
            try
            {
                Json(await Task.FromResult(this.ILaboratorio.Delete(laboratorio)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o laboratorio " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
