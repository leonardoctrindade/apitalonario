using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ContaCorrenteApiController : Controller
    {
        private readonly IContaCorrente iContaCorrente;
        public ContaCorrenteApiController(IContaCorrente icontacorrente)
        {
            iContaCorrente = icontacorrente;
        }

        [HttpGet("/api/ListarContaCorrente")]
        public async Task<JsonResult> ListarContaCorrente()
        {
            return Json(await this.iContaCorrente.List());
        }
        [HttpPost("/api/AdicionarContaCorrente")]
        public async Task<JsonResult> AdicionarContaCorrente([FromBody] ContaCorrente contaCorrente)
        {
            if (string.IsNullOrEmpty(contaCorrente.Nome) || contaCorrente.Limite <= 0 || string.IsNullOrEmpty(contaCorrente.NumeroConta))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.iContaCorrente.Add(contaCorrente)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarContaCorrentePorId/{id}")]
        public async Task<JsonResult> RetornarContaCorrentePorId(int id)
        {
            return Json(await this.iContaCorrente.GetEntityById(id));
        }
        [HttpPost("/api/EditarContaCorrente")]
        public async Task<JsonResult> EditarContaCorrente([FromBody] ContaCorrente contaCorrente)
        {
            if (string.IsNullOrEmpty(contaCorrente.Nome) || contaCorrente.Limite < 0 || string.IsNullOrEmpty(contaCorrente.NumeroConta))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.iContaCorrente.Update(contaCorrente)));

            return Json(Ok());
        }
        [HttpPost("api/ExcluirContaCorrente")]
        public async Task ExcluirContaCorrente([FromBody] ContaCorrente contaCorrente)
        {
            await Task.FromResult(this.iContaCorrente.Delete(contaCorrente));
        }

    }
}
