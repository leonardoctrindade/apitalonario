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
    public class FormaFarmaceuticaFaixaApiController: Controller
    {
        private readonly IFormaFarmaceuticaFaixa IFormaFarmaceuticaFaixa;

        public FormaFarmaceuticaFaixaApiController(IFormaFarmaceuticaFaixa IFormaFarmaceuticaFaixa)
        {
            this.IFormaFarmaceuticaFaixa = IFormaFarmaceuticaFaixa;
        }

        [HttpGet("/api/ListaPaginacaoFormaFarmaceuticaFaixa/{pagina}")]
        public async Task<JsonResult> ListaPaginacao(int pagina)
        {
            try
            {
                var formasFarmaceuticas = await this.IFormaFarmaceuticaFaixa.List();

                var total = Convert.ToDouble(formasFarmaceuticas.Count() / 10);

                var num = total / 2;

                if (!num.Equals(0)) total = total + 1;

                var listGroup = await this.IFormaFarmaceuticaFaixa.ListagemCustomizada(pagina);

                return Json(listGroup.Count() > 0 ? new { listGroup, total } : formasFarmaceuticas);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as formas farmaceuticas " + ex.Message }) { StatusCode = 400 };
            }
        }


        [HttpGet("/api/ListaFormaFarmaceuticaFaixa")]
        public async Task<JsonResult> ListaFormaFarmaceuticaFaixa()
        {
            try
            {
                return Json(await this.IFormaFarmaceuticaFaixa.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as forma farmaceutica faixa " + ex.Message }) { StatusCode = 400 };
            }

        }

        [HttpPost("/api/AdicionarFormaFarmaceuticaFaixa")]
        public async Task<IActionResult> AdicionarFormaFarmaceuticaFaixa([FromBody] FormaFarmaceuticaFaixa FormaFarmaceuticaFaixa)
        {
            try
            {
                if (FormaFarmaceuticaFaixa.FormaFarmaceuticaId == 0)
                    return BadRequest("Campo de FormaFarmaceutica é obrigatório");

                Json(await Task.FromResult(this.IFormaFarmaceuticaFaixa.Add(FormaFarmaceuticaFaixa)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionara a forma farmaceutica faixa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFormaFarmaceuticaFaixaPorId/{id}")]
        public async Task<JsonResult> RetornaFormaFarmaceuticaFaixaPorId(int id)
        {
            try
            {
                return Json(await this.IFormaFarmaceuticaFaixa.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFormaFarmaceuticaFaixa")]
        public async Task<IActionResult> EditarFormaFarmaceuticaFaixa([FromBody] FormaFarmaceuticaFaixa FormaFarmaceuticaFaixa)
        {
            try
            {
                if (FormaFarmaceuticaFaixa.FormaFarmaceuticaId == 0)
                    return BadRequest("Campo de FormaFarmaceutica é obrigatório");

                Json(await Task.FromResult(this.IFormaFarmaceuticaFaixa.Update(FormaFarmaceuticaFaixa)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar a forma farmaceutica faixa " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFormaFarmaceuticaFaixa")]
        public async Task<JsonResult> ExcluirFormaFarmaceuticaFaixa([FromBody] FormaFarmaceuticaFaixa FormaFarmaceuticaFaixa)
        {
            try
            {
                Json(await Task.FromResult(this.IFormaFarmaceuticaFaixa.Delete(FormaFarmaceuticaFaixa)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a forma farmaceutica faixa " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
