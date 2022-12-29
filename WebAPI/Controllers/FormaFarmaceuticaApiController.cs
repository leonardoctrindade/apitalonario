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
    public class FormaFarmaceuticaApiController: Controller
    {
        private readonly IFormaFarmaceutica IFormaFarmaceutica;

        public FormaFarmaceuticaApiController(IFormaFarmaceutica IFormaFarmaceutica)
        {
            this.IFormaFarmaceutica = IFormaFarmaceutica;
        }

        [HttpGet("/api/ListaFormaFarmaceutica")]
        public async Task<JsonResult> ListaFormaFarmaceutica()
        {
            try
            {
                return Json(await this.IFormaFarmaceutica.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar as forma farmaceuticas" + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarFormaFarmaceutica")]
        public async Task<JsonResult> AdicionarFormaFarmaceutica([FromBody] FormaFarmaceutica FormaFarmaceutica)
        {
            try
            {
                if (String.IsNullOrEmpty(FormaFarmaceutica.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFormaFarmaceutica.Add(FormaFarmaceutica)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar a forma farmaceutica " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaFormaFarmaceuticaPorId/{id}")]
        public async Task<JsonResult> RetornaFormaFarmaceuticaPorId(int id)
        {
            try
            {
                return Json(await this.IFormaFarmaceutica.GetFormaFarmaceutica(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarFormaFarmaceutica")]
        public async Task<JsonResult> EditarFormaFarmaceutica([FromBody] FormaFarmaceutica FormaFarmaceutica)
        {
            try
            {
                if (String.IsNullOrEmpty(FormaFarmaceutica.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IFormaFarmaceutica.Update(FormaFarmaceutica)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirFormaFarmaceutica")]
        public async Task<JsonResult> ExcluirFormaFarmaceutica([FromBody] FormaFarmaceutica FormaFarmaceutica)
        {
            try
            {
                Json(await Task.FromResult(this.IFormaFarmaceutica.Delete(FormaFarmaceutica)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o adiministrador de cartão " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
