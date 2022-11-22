using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class PrincipioAtivoApiController : Controller
    {
        private readonly IPrincipioAtivo IPrincipioAtivo;
        public PrincipioAtivoApiController(IPrincipioAtivo iprincipioAtivo)
        {
            IPrincipioAtivo = iprincipioAtivo;
        }
        [HttpGet("/api/ListaPrincipioAtivo")]
        public async Task<JsonResult> ListaPrincipioAtivo()
        {
            return Json(await this.IPrincipioAtivo.List());
        }
        [HttpPost("/api/AdicionarPrincipioAtivo")]
        public async Task<JsonResult> AdicionarPrincipioAtivo([FromBody] PrincipioAtivo principioAtivo)
        {
            if (string.IsNullOrEmpty(principioAtivo.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPrincipioAtivo.Add(principioAtivo)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarPrincipioAtivoProId/{id}")]
        public async Task<JsonResult> RetornarPrincipioAtivoProId(int id)
        {
            if (id == 0)
                return Json(BadRequest(ModelState));
            return Json(await this.IPrincipioAtivo.GetEntityById(id));
        }
        [HttpPost("/api/EditarPrincipioAtivo")]
        public async Task<JsonResult> EditarPrincipioAtivo([FromBody] PrincipioAtivo principioAtivo)
        {
            if (string.IsNullOrEmpty(principioAtivo.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPrincipioAtivo.Update(principioAtivo)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirPrincipioAtivo")]
        public async Task ExcluirPrincipioAtivo([FromBody] PrincipioAtivo principioAtivo)
        {
            await Task.FromResult(this.IPrincipioAtivo.Delete(principioAtivo));
        }
    }
}
