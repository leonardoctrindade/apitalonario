using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class LaboratorioApiController : Controller
    {
        private readonly ILaboratorio ILaboratorio;

        public LaboratorioApiController(ILaboratorio ilaboratorio)
        {
            this.ILaboratorio = ilaboratorio;
        }
        [HttpGet("/api/ListaLaboratorio")]
        public async Task<JsonResult> ListaLaboratorio()
        {
            return Json(await this.ILaboratorio.List());
        }
        [HttpPost("/api/AdicionarLaboratorio")]
        public async Task<JsonResult> AdicionarLaboratorio([FromBody] Laboratorio laboratorio)
        {
            if (string.IsNullOrEmpty(laboratorio.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ILaboratorio.Add(laboratorio)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarLaboratorioId/{id}")]
        public async Task<JsonResult> RetornarLaboratorioId(int id)
        {
            if (id <= 0)
                return Json(BadRequest(ModelState));

            return Json(await this.ILaboratorio.GetEntityById(id));
        }
        [HttpPost("/api/EditarLaboratorio")]
        public async Task<JsonResult> EditarLaboratorio([FromBody] Laboratorio laboratorio)
        {
            if (string.IsNullOrEmpty(laboratorio.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.ILaboratorio.Update(laboratorio)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirLaboratorio")]
        public async Task ExcluirLaboratorio([FromBody] Laboratorio laboratorio)
        {
            await Task.FromResult(this.ILaboratorio.Delete(laboratorio));
        }
    }
}
