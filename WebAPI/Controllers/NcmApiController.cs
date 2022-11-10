using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class NcmApiController : Controller
    {
        private readonly INcm INcm;

        public NcmApiController(INcm INcm)
        {
            this.INcm = INcm;
        }

        [HttpGet("/api/ListaNcm")]
        public async Task<JsonResult> ListaNcm()
        {
            return Json(await this.INcm.List());
        }

        [HttpPost("/api/AdicionarNcm")]
        public async Task<JsonResult> AdicionarNcm([FromBody] Ncm Ncm)
        {
            if (String.IsNullOrEmpty(Ncm.Descricao))
                return Json(BadRequest(ModelState));
            if (string.IsNullOrEmpty(Ncm.CodigoNcm))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.INcm.Add(Ncm)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaNcmPorId/{id}")]
        public async Task<JsonResult> RetornaNcmPorId(int id)
        {
            return Json(await this.INcm.GetEntityById(id));
        }

        [HttpPost("/api/EditarNcm")]
        public async Task<JsonResult> EditarNcm([FromBody] Ncm Ncm)
        {
            if (String.IsNullOrEmpty(Ncm.Descricao))
                return Json(BadRequest(ModelState));
            if (string.IsNullOrEmpty(Ncm.CodigoNcm))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.INcm.Update(Ncm)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirNcm")]
        public async Task ExcluirNcm([FromBody] Ncm Ncm)
        {
            await Task.FromResult(this.INcm.Delete(Ncm));
        }
    }
}
