using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class DcbApiController : Controller
    {
        private readonly IDcb iDcb;
        public DcbApiController(IDcb idcb)
        {
            iDcb = idcb;
        }
        [HttpGet("/api/ListarDcb")]
        public async Task<JsonResult> ListarDcb()
        {
            return Json(await this.iDcb.List());
        }
        [HttpPost("/api/AdicionarDcb")]
        public async Task<JsonResult> AdicionarDcb([FromBody] Dcb dcb)
        {
            if (string.IsNullOrEmpty(dcb.Descricao) || string.IsNullOrEmpty(dcb.CodigoDcb))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.iDcb.Add(dcb)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarDcbPorId/{id}")]
        public async Task<JsonResult> RetornarDcbPorId(int id)
        {
            return Json(await this.iDcb.GetEntityById(id));
        }
        [HttpPost("/api/EditarDcb")]
        public async Task<JsonResult> EditarDcb([FromBody] Dcb dcb)
        {
            if (string.IsNullOrEmpty(dcb.Descricao) || string.IsNullOrEmpty(dcb.CodigoDcb))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.iDcb.Update(dcb)));

            return Json(Ok());
        }
        [HttpPost("api/ExcluirDcb")]
        public async Task ExcluirDcb([FromBody] Dcb dcb)
        {
            await Task.FromResult(this.iDcb.Delete(dcb));
        }
    }
}
