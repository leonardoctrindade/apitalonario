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
    public class TipoCapsulaApiController : Controller
    {
        private readonly ITipoCapsula ITipoCapsula;

        public TipoCapsulaApiController(ITipoCapsula ITipoCapsula)
        {
            this.ITipoCapsula = ITipoCapsula;
        }

        [HttpGet("/api/ListaTipoCapsula")]
        public async Task<JsonResult> ListaTipoCapsula()
        {
            try
            {
                return Json(await this.ITipoCapsula.List());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os tipos de capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/AdicionarTipoCapsula")]
        public async Task<JsonResult> AdicionarTipoCapsula([FromBody] TipoCapsula TipoCapsula)
        {
            try
            {
                if (String.IsNullOrEmpty(TipoCapsula.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITipoCapsula.Add(TipoCapsula)));

                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o tipo de capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpGet("/api/RetornaTipoCapsulaPorId/{id}")]
        public async Task<JsonResult> RetornaTipoCapsulaPorId(int id)
        {
            try
            {
                return Json(await this.ITipoCapsula.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o tipo de capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarTipoCapsula")]
        public async Task<JsonResult> EditarTipoCapsula([FromBody] TipoCapsula TipoCapsula)
        {
            try
            {
                if (String.IsNullOrEmpty(TipoCapsula.Descricao))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.ITipoCapsula.Update(TipoCapsula)));
                return Json(Ok());
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o tipo de capsula " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirTipoCapsula")]
        public async Task<JsonResult> ExcluirTipoCapsula([FromBody] TipoCapsula TipoCapsula)
        {
            try
            {
                return Json(await Task.FromResult(this.ITipoCapsula.Delete(TipoCapsula)));
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o tipo de capsula " + ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
