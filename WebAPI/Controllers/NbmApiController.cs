using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class NbmApiController : Controller
    {
        private readonly INbm INbm;

        public NbmApiController(INbm iNbm)
        {
            this.INbm = iNbm;
        }
        [HttpGet("/api/ListaNbm")]
        public async Task<JsonResult> ListaNbm()
        {
            return Json(await this.INbm.List());
        }
        [HttpPost("/api/AdicionarNbm")]
        public async Task<JsonResult> AdicionarNbm([FromBody] Nbm nbm)
        {
            if (string.IsNullOrEmpty(nbm.CodigoNbm) || string.IsNullOrEmpty(nbm.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.INbm.Add(nbm)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarNbmProId/{id}")]
        public async Task<JsonResult> RetornarNbmPorId(int id)
        {
            if (id == 0)
                return Json(BadRequest(ModelState));

            return Json(await this.INbm.GetEntityById(id));
        }
        [HttpPost("/api/EditarNbm")]
        public async Task<JsonResult> EditarNbm([FromBody] Nbm nbm)
        {
            if (string.IsNullOrEmpty(nbm.CodigoNbm) || string.IsNullOrEmpty(nbm.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.INbm.Update(nbm)));
            return Json(Ok());
        }
        [HttpPost("/api/ExcluirNbm")]
        public async Task ExcluirNbm([FromBody] Nbm nbm)
        {
            await Task.FromResult(this.INbm.Delete(nbm));
        }
    }
}
