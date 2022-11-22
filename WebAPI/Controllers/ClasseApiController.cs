using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ClasseApiController : Controller
    {
        private readonly IClasse IClasse;

        public ClasseApiController(IClasse iclasse)
        {
            IClasse = iclasse;
        }
        [HttpGet("/api/ListaClasse")]
        public async Task<JsonResult> ListaClasse()
        {
            return Json(await this.IClasse.List());
        }
        [HttpPost("/api/AdicionarClasse")]
        public async Task<JsonResult> AdicionarClasse([FromBody] Classe classe)
        {
            if (string.IsNullOrEmpty(classe.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IClasse.Add(classe)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarClassePorId/{id}")]
        public async Task<JsonResult> RetornarClassePorId(int id)
        {
            if (id == 0)
                return Json(BadRequest(ModelState));
            return Json(await this.IClasse.GetEntityById(id));
        }
        [HttpPost("/api/EditarClasse")]
        public async Task<JsonResult> EditarClasse([FromBody] Classe classe)
        {
            if (string.IsNullOrEmpty(classe.Descricao))
                return Json(BadRequest(ModelState));
            Json(await Task.FromResult(this.IClasse.Update(classe)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirClasse")]
        public async Task ExcluirClasse([FromBody] Classe classe)
        {
            await Task.FromResult(this.IClasse.Delete(classe));
        }
    }
}
