using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class DciApiController : Controller
    {
        private readonly IDci IDci;
        
        public DciApiController(IDci idci)
        {
            IDci = idci;
        }
        [HttpGet("/api/ListaDci")]
        public async Task<JsonResult> ListaDci()
        {
            return Json(await this.IDci.List());
        }
        [HttpPost("/api/AdicionarDci")]
        public async Task<JsonResult> AdicionarDci([FromBody] Dci dci)
        {
            if (string.IsNullOrEmpty(dci.CodigoDci) || string.IsNullOrEmpty(dci.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IDci.Add(dci)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarPorId/{id}")]
        public async Task<JsonResult> RetornarPorId(int id)
        {
            return Json(await this.IDci.GetEntityById(id));
        }
        [HttpPost("/api/EditarDci")]
        public async Task<JsonResult> EditarDci([FromBody] Dci dci)
        {
            if (string.IsNullOrEmpty(dci.CodigoDci) || string.IsNullOrEmpty(dci.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IDci.Update(dci)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirDci")]
        public async Task ExcluirDci([FromBody] Dci dci)
        {
            await Task.FromResult(this.IDci.Delete(dci));
        }
    }
}
