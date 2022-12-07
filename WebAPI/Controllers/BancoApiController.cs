using Data.Entidades;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class BancoApiController : Controller
    {
        private readonly IBanco IBanco;

        public BancoApiController(IBanco IBanco)
        {
            this.IBanco = IBanco;
        }

        [HttpGet("/api/ListaBanco")]
        public async Task<JsonResult> ListaBanco()
        {
            return Json(await this.IBanco.List());
        }

        [HttpPost("/api/AdicionarBanco")]
        public async Task<JsonResult> AdicionarBanco([FromBody] Banco Banco)
        {
            if (String.IsNullOrEmpty(Banco.Nome))
                return Json(BadRequest(ModelState));
            if (Banco.CodigoBanco.Count() == 0 || Banco.CodigoBanco.Count() > 3 ) 
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IBanco.Add(Banco)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaBancoPorId/{id}")]
        public async Task<JsonResult> RetornaBancoPorId(int id)
        {
            return Json(await this.IBanco.GetEntityById(id));
        }

        [HttpPost("/api/EditarBanco")]
        public async Task<JsonResult> EditarBanco([FromBody] Banco Banco)
        {
            if (String.IsNullOrEmpty(Banco.Nome))
                return Json(BadRequest(ModelState));
            if (Banco.CodigoBanco.Count() == 0 || Banco.CodigoBanco.Count() > 3 )
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IBanco.Update(Banco)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirBanco")]
        public async Task ExcluirBanco([FromBody] Banco Banco)
        {
            await Task.FromResult(this.IBanco.Delete(Banco));
        }
    }
}
