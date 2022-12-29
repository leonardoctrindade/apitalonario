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
        public async Task<JsonResult> AdicionarFormaFarmaceuticaFaixa([FromBody] FormaFarmaceuticaFaixa FormaFarmaceuticaFaixa)
        {
            try
            {
                if (FormaFarmaceuticaFaixa.FormaFarmaceuticaId == null || FormaFarmaceuticaFaixa.FormaFarmaceuticaId == 0)
                    return Json(BadRequest(ModelState));

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
                return Json(await this.IFormaFarmaceuticaFaixa.GetFormaFarmaceuticaFaixa(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFormaFarmaceuticaFaixa")]
        public async Task<JsonResult> EditarFormaFarmaceuticaFaixa([FromBody] FormaFarmaceuticaFaixa FormaFarmaceuticaFaixa)
        {
            try
            {
                if (FormaFarmaceuticaFaixa.FormaFarmaceuticaId == null || FormaFarmaceuticaFaixa.FormaFarmaceuticaId == 0)
                    return Json(BadRequest(ModelState));

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
