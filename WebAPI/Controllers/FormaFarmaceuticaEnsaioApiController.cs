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
        public async Task<JsonResult> AdicionarFormaFarmaceuticaEnsaio([FromBody] FormaFarmaceuticaEnsaio FormaFarmaceuticaEnsaio)
        {
            try
            {
                if (String.IsNullOrEmpty(FormaFarmaceuticaEnsaio.Descricao))
                    return Json(BadRequest(ModelState));
                if (FormaFarmaceuticaEnsaio.FormaFarmaceuticaId <= 0)
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarFormaFarmaceuticaEnsaio([FromBody] FormaFarmaceuticaEnsaio FormaFarmaceuticaEnsaio)
        {
            try
            {
                if (String.IsNullOrEmpty(FormaFarmaceuticaEnsaio.Descricao))
                    return Json(BadRequest(ModelState));
                if (FormaFarmaceuticaEnsaio.FormaFarmaceuticaId <= 0)
                    return Json(BadRequest(ModelState));

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
                return Json(await Task.FromResult(this.IFormaFarmaceuticaEnsaio.Delete(FormaFarmaceuticaEnsaio)));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir a forma farmaceutica ensaio " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
