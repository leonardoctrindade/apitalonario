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
    public class FormaFarmaceuticaMargemApiController: Controller
    {
        private readonly IFormaFarmaceuticaMargem IFormaFarmaceuticaMargem;

        public FormaFarmaceuticaMargemApiController(IFormaFarmaceuticaMargem IFormaFarmaceuticaMargem)
        {
            this.IFormaFarmaceuticaMargem = IFormaFarmaceuticaMargem;
        }

        [HttpGet("/api/ListaPaginacaoFormaFarmaceuticaMargem/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var formaFarmaceuticas = await this.IFormaFarmaceuticaMargem.List();

                var total = Convert.ToDouble(formaFarmaceuticas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IFormaFarmaceuticaMargem.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : formaFarmaceuticas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as forma farmaceuticas margem" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaFormaFarmaceuticaMargem")]
        public async Task<JsonResult> ListaFormaFarmaceuticaMargem()
        {
            try
            {
                return Json(await this.IFormaFarmaceuticaMargem.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as forma farmaceutica margem " + ex.Message }) { StatusCode = 400 };
            }

        }

        [HttpPost("/api/AdicionarFormaFarmaceuticaMargem")]
        public async Task<IActionResult> AdicionarFormaFarmaceuticaMargem([FromBody] FormaFarmaceuticaMargem FormaFarmaceuticaMargem)
        {
            try
            {
                if (FormaFarmaceuticaMargem.FormaFarmaceuticaId == 0)
                    return BadRequest("Campo de Forma Farmaceutica é obrigatório");
                if (FormaFarmaceuticaMargem.Margem <= 0)
                    return BadRequest("Campo de Margem é obrigatório");

                Json(await Task.FromResult(this.IFormaFarmaceuticaMargem.Add(FormaFarmaceuticaMargem)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a forma farmaceutica margem " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFormaFarmaceuticaMargemPorId/{id}")]
        public async Task<JsonResult> RetornaFormaFarmaceuticaMargemPorId(int id)
        {
            try
            {
                return Json(await this.IFormaFarmaceuticaMargem.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a forma farmaceutica margem " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFormaFarmaceuticaMargem")]
        public async Task<IActionResult> EditarFormaFarmaceuticaMargem([FromBody] FormaFarmaceuticaMargem FormaFarmaceuticaMargem)
        {
            try
            {
                if (FormaFarmaceuticaMargem.FormaFarmaceuticaId == 0)
                    return BadRequest("Campo de Forma Farmaceutica é obrigatório");
                if (FormaFarmaceuticaMargem.Margem <= 0)
                    return BadRequest("Campo de Margem é obrigatório");

                Json(await Task.FromResult(this.IFormaFarmaceuticaMargem.Update(FormaFarmaceuticaMargem)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a forma farmaceutica margem " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFormaFarmaceuticaMargem")]
        public async Task<JsonResult> ExcluirFormaFarmaceuticaMargem([FromBody] FormaFarmaceuticaMargem FormaFarmaceuticaMargem)
        {
            try
            {
                Json(await Task.FromResult(this.IFormaFarmaceuticaMargem.Delete(FormaFarmaceuticaMargem)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a forma farmaceutica margem " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
