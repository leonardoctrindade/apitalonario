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
    [Authorize]
    public class FarmacopeiaApiController : Controller
    {
        private readonly IFarmacopeia IFarmacopeia;

        public FarmacopeiaApiController(IFarmacopeia IFarmacopeia)
        {
            this.IFarmacopeia = IFarmacopeia;
        }

        [HttpGet("/api/ListaFarmacopeia")]
        public async Task<JsonResult> ListaFarmacopeia()
        {
            //return Json(await this.IFarmacopeia.List());

            return Json(new List<Farmacopeia>()
            {
                new Farmacopeia { Id = 1, Nome = "Teste 1", Observacao = "Teste Observação 1"},
                new Farmacopeia { Id = 2, Nome = "Teste 2", Observacao = "Teste Observação 2"},
                new Farmacopeia { Id = 3, Nome = "Teste 3", Observacao = "Teste Observação 3"}
            });
        }

        [HttpPost("/api/AdicionarFarmacopeia")]
        public async Task<JsonResult> AdicionarFarmacopeia([FromBody] Farmacopeia Farmacopeia)
        {
            if (String.IsNullOrEmpty(Farmacopeia.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFarmacopeia.Add(Farmacopeia)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaFarmacopeiaPorId/{id}")]
        public async Task<JsonResult> RetornaFarmacopeiaPorId(int id)
        {
            return Json(await this.IFarmacopeia.GetEntityById(id));
        }

        [HttpPost("/api/EditarFarmacopeia")]
        public async Task<JsonResult> EditarFarmacopeia([FromBody] Farmacopeia Farmacopeia)
        {
            if (String.IsNullOrEmpty(Farmacopeia.Nome))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IFarmacopeia.Update(Farmacopeia)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirFarmacopeia")]
        public async Task ExcluirFarmacopeia([FromBody] Farmacopeia Farmacopeia)
        {
            await Task.FromResult(this.IFarmacopeia.Delete(Farmacopeia));
        }
    }
}
