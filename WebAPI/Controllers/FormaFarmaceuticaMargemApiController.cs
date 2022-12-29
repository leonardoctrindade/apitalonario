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
        public async Task<JsonResult> AdicionarFormaFarmaceuticaMargem([FromBody] FormaFarmaceuticaMargem FormaFarmaceuticaMargem)
        {
            try
            {
                if (FormaFarmaceuticaMargem.FormaFarmaceuticaId == 0)
                    return Json(BadRequest(ModelState));
                if (FormaFarmaceuticaMargem.Margem <= 0)
                    return Json(BadRequest(ModelState));

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
        public async Task<JsonResult> EditarFormaFarmaceuticaMargem([FromBody] FormaFarmaceuticaMargem FormaFarmaceuticaMargem)
        {
            try
            {
                if (FormaFarmaceuticaMargem.FormaFarmaceuticaId == 0)
                    return Json(BadRequest(ModelState));
                if (FormaFarmaceuticaMargem.Margem <= 0)
                    return Json(BadRequest(ModelState));

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
