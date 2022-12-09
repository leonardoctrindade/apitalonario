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
    public class PlanoDeContasApiController : Controller
    {
        private readonly IPlanoDeContas IPlanoDeContas;

        public PlanoDeContasApiController(IPlanoDeContas iPlanoDeContas)
        {
            IPlanoDeContas = iPlanoDeContas;
        }
        [HttpGet("/api/ListaPlanoDeContas")]
        public async Task<JsonResult> ListaPlanoDeContas()
        {
            var listaPlanoDeContas = await this.IPlanoDeContas.List();

            var listaView = new ViewPlanoDeContas();
            
            foreach (var planoDeconta in listaPlanoDeContas)
            {
                if(planoDeconta.NivelConta == 1)
                    listaView.Nivel1.Add(planoDeconta);
                if (planoDeconta.NivelConta == 2)
                    listaView.Nivel2.Add(planoDeconta);
                if (planoDeconta.NivelConta == 3)
                    listaView.Nivel3.Add(planoDeconta);
            }

            return Json(listaView);
        }
        [HttpPost("/api/AdicionarPlanoDeContas")]
        public async Task<JsonResult> AdicionarPlanoDeContas([FromBody] PlanoDeContas planoDeContas)
        {
            if (string.IsNullOrEmpty(planoDeContas.NumeroContaPai) ||
                planoDeContas.NivelConta <= 0 ||
                string.IsNullOrEmpty(planoDeContas.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPlanoDeContas.Add(planoDeContas)));

            return Json(Ok());
        }
        [HttpGet("/api/RetornarPlanoDeContasPorId/{id}")]
        public async Task<JsonResult> RetornarPlanoDeContasPorId(int id)
        {
            return Json(await this.IPlanoDeContas.GetEntityById(id));
        }
        [HttpPost("/api/EditarPlanoDeContas")]
        public async Task<JsonResult> EditarPlanoDeContas([FromBody] PlanoDeContas planoDeContas)
        {
            if (string.IsNullOrEmpty(planoDeContas.NumeroContaPai) ||
                planoDeContas.NivelConta <= 0 ||
                string.IsNullOrEmpty(planoDeContas.Descricao))
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IPlanoDeContas.Update(planoDeContas)));

            return Json(Ok());
        }
        [HttpPost("/api/ExcluirPlanoDeContas")]
        public async Task ExcluirPlanoDeContas([FromBody] PlanoDeContas planoDeContas)
        {
            await Task.FromResult(this.IPlanoDeContas.Delete(planoDeContas));
        } 
    }
}
