using System;
using System.Linq;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    public class BairroApiController : Controller
    {
        private readonly IBairro IBairro;

        public BairroApiController(IBairro iBairro)
        {
            this.IBairro = iBairro;
        }

        [HttpGet("/api/ListaBairro")]
        public async Task<JsonResult> ListaBairro()
        {
            return Json(await this.IBairro.List());
            //return Json(new List<Bairro>()
            //{
            //    new Bairro() { Id = 1, Nome = "Teste 1"},
            //    new Bairro() { Id = 2, Nome = "Teste 2"},
            //    new Bairro() { Id = 3, Nome = "Teste 3"}
            //});
        }

        [HttpPost("/api/AdicionarBairro")]
        public async Task<JsonResult> AdicionarBairro([FromBody] Bairro Bairro)
        {
            if (String.IsNullOrEmpty(Bairro.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IBairro.Add(Bairro)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaBairroPorId/{id}")]
        public async Task<JsonResult> RetornaBairroPorId(int id)
        {
            return Json(await this.IBairro.GetEntityById(id));
        }

        [HttpPost("/api/EditarBairro")]
        public async Task<JsonResult> EditarBairro([FromBody] Bairro Bairro)
        {
            if (String.IsNullOrEmpty(Bairro.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IBairro.Update(Bairro)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirBairro")]
        public async Task ExcluirBairro([FromBody] Bairro Bairro)
        {
            await Task.FromResult(this.IBairro.Delete(Bairro));
        }
    }
}
