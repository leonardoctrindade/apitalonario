using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Authorize]
    public class PbmApiController : Controller
    {
        private readonly IPbm IPbm;
        public PbmApiController(IPbm IPbm)
        {
            this.IPbm = IPbm;
        }


        [HttpGet("/api/ListaPbm")]
        public async Task<JsonResult> ListaPbm()
        {
            try
            {
                return Json(await this.IPbm.List());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao listar os pbms " + ex.Message }) { StatusCode = 400 };
            }
        }


        [HttpPost("/api/AdicionarPbm")]
        public async Task<JsonResult> AdicionarPbm([FromBody] Pbm Pbm)
        {
            try
            {
                if (String.IsNullOrEmpty(Pbm.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPbm.Add(Pbm)));

                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao adicionar o pbm " + ex.Message }) { StatusCode = 400 };
            }
        }


        [HttpGet("/api/RetornaPbmPorId/{id}")]
        public async Task<JsonResult> RetornaPbmPorId(int id)
        {
            try
            {
                return Json(await this.IPbm.GetEntityById(id));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao retornar o pbm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/EditarPbm")]
        public async Task<JsonResult> EditarPbm([FromBody] Pbm Pbm)
        {
            try
            {
                if (String.IsNullOrEmpty(Pbm.Nome))
                    return Json(BadRequest(ModelState));

                Json(await Task.FromResult(this.IPbm.Update(Pbm)));
                return Json(Ok());
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao editar o pbm " + ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("/api/ExcluirPbm")]
        public async Task<JsonResult> ExcluirBpm([FromBody] Pbm Pbm)
        {
            try
            {
                return Json(await Task.FromResult(this.IPbm.Delete(Pbm)));
            }
            catch(Exception ex)
            {
                return new JsonResult(new { message = "Error ao excluir o pbm " + ex.Message }) { StatusCode = 400 };
            }
        }

    }
}