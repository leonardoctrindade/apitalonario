using System;
using Data.Entidades;
using Data.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class DiferimentoApiController : Controller
    {
        private readonly IDiferimento IDiferimento;

        public DiferimentoApiController(IDiferimento IDiferimento)
        {
            this.IDiferimento = IDiferimento;
        }

        [HttpGet("/api/ListaDiferimento")]
        public async Task<JsonResult> ListaDiferimento()
        {
            return Json(await this.IDiferimento.List());
        }

        [HttpPost("/api/AdicionarDiferimento")]
        public async Task<JsonResult> AdicionarDiferimento([FromBody] Diferimento Diferimento)
        {
            if (String.IsNullOrEmpty(Diferimento.Cst))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Diferimento.SiglaEstado))
                return Json(BadRequest(ModelState));
            if (Diferimento.AliquotaDiferimento <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IDiferimento.Add(Diferimento)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornaDiferimentoPorId/{id}")]
        public async Task<JsonResult> RetornaDiferimentoPorId(int id)
        {
            return Json(await this.IDiferimento.GetEntityById(id));
        }

        [HttpPost("/api/EditarDiferimento")]
        public async Task<JsonResult> EditarDiferimento([FromBody] Diferimento Diferimento)
        {
            if (String.IsNullOrEmpty(Diferimento.Cst))
                return Json(BadRequest(ModelState));
            if (String.IsNullOrEmpty(Diferimento.SiglaEstado))
                return Json(BadRequest(ModelState));
            if (Diferimento.AliquotaDiferimento <= 0)
                return Json(BadRequest(ModelState));

            Json(await Task.FromResult(this.IDiferimento.Update(Diferimento)));
            return Json(Ok());
        }

        [HttpPost("/api/ExcluirDiferimento")]
        public async Task ExcluirDiferimento([FromBody] Diferimento Diferimento)
        {
            await Task.FromResult(this.IDiferimento.Delete(Diferimento));
        }
    }
}
