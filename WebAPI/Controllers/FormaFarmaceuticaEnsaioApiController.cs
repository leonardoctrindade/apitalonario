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
    public class FormaFarmaceuticaEnsaioApiController : Controller
    {
        private readonly IFormaFarmaceuticaEnsaio IFormaFarmaceuticaEnsaio;

        public FormaFarmaceuticaEnsaioApiController(IFormaFarmaceuticaEnsaio IFormaFarmaceuticaEnsaio)
        {
            this.IFormaFarmaceuticaEnsaio = IFormaFarmaceuticaEnsaio;
        }

        [HttpGet("/api/ListaPaginacaoFormaFarmaceuticaEnsaio/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var formaFarmaceuticasEnsaio = await this.IFormaFarmaceuticaEnsaio.List();

                var total = Convert.ToDouble(formaFarmaceuticasEnsaio.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IFormaFarmaceuticaEnsaio.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : formaFarmaceuticasEnsaio);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as formas farmaceuticas ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/ListaFormaFarmaceuticaEnsaio")]
        public async Task<JsonResult> ListaFormaFarmaceuticaEnsaio()
        {
            try
            {
                return Json(await this.IFormaFarmaceuticaEnsaio.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as forma farmaceutica ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFormaFarmaceuticaEnsaio")]
        public async Task<IActionResult> AdicionarFormaFarmaceuticaEnsaio([FromBody] FormaFarmaceuticaEnsaio FormaFarmaceuticaEnsaio)
        {
            try
            {
                if (String.IsNullOrEmpty(FormaFarmaceuticaEnsaio.Descricao.Trim()))
                    return BadRequest("Campo de descrção é obrigatório");
                if (FormaFarmaceuticaEnsaio.FormaFarmaceuticaId <= 0)
                    return BadRequest("Campo de formaFarmaceutica é obrigatório");

                Json(await Task.FromResult(this.IFormaFarmaceuticaEnsaio.Add(FormaFarmaceuticaEnsaio)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a forma farmaceutica ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFormaFarmaceuticaEnsaioPorId/{id}")]
        public async Task<JsonResult> RetornaFormaFarmaceuticaEnsaioPorId(int id)
        {
            try
            {
                return Json(await this.IFormaFarmaceuticaEnsaio.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar a forma farmaceutica ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFormaFarmaceuticaEnsaio")]
        public async Task<IActionResult> EditarFormaFarmaceuticaEnsaio([FromBody] FormaFarmaceuticaEnsaio FormaFarmaceuticaEnsaio)
        {
            try
            {
                if (String.IsNullOrEmpty(FormaFarmaceuticaEnsaio.Descricao.Trim()))
                    return BadRequest("Campo de descrção é obrigatório");
                if (FormaFarmaceuticaEnsaio.FormaFarmaceuticaId <= 0)
                    return BadRequest("Campo de formaFarmaceutica é obrigatório");

                Json(await Task.FromResult(this.IFormaFarmaceuticaEnsaio.Update(FormaFarmaceuticaEnsaio)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a forma farmaceutica ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFormaFarmaceuticaEnsaio")]
        public async Task<JsonResult> ExcluirFormaFarmaceuticaEnsaio([FromBody] FormaFarmaceuticaEnsaio FormaFarmaceuticaEnsaio)
        {
            try
            {
                Json(await Task.FromResult(this.IFormaFarmaceuticaEnsaio.Delete(FormaFarmaceuticaEnsaio)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a forma farmaceutica ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
