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
    public class ContabilistaApiController : Controller
    {
        private readonly IContabilista IContabilista;

        public ContabilistaApiController(IContabilista icontabilista)
        {
            IContabilista = icontabilista;
        }

        [HttpGet("/api/ListaContabilista")]
        public async Task<JsonResult> ListaContabilista()
        {
            return Json(await this.IContabilista.List());
        }

        [HttpPost("/api/AdicionarContabilista")]
        public async Task<JsonResult> AdicionarContabilista([FromBody] Contabilista contabilista)
        {
            if(string.IsNullOrEmpty(contabilista.Nome) || string.IsNullOrEmpty(contabilista.Cpf)
               || string.IsNullOrEmpty(contabilista.Cnpj) || string.IsNullOrEmpty(contabilista.Crc))
            {
                return Json(BadRequest(ModelState));
            }

            Json(await Task.FromResult(this.IContabilista.Add(contabilista)));

            return Json(Ok());
        }

        [HttpGet("/api/RetornarContabilistaPorId/{id}")]
        public async Task<JsonResult> RetornarContabilistaPorId(int id)
        {
            return Json(await this.IContabilista.GetEntityById(id));
        }

        [HttpPost("/api/EditarContabilista")]
        public async Task<JsonResult> EditarContabilista([FromBody] Contabilista contabilista)
        {
            if (string.IsNullOrEmpty(contabilista.Nome) || string.IsNullOrEmpty(contabilista.Cpf)
               || string.IsNullOrEmpty(contabilista.Cnpj) || string.IsNullOrEmpty(contabilista.Crc))
            {
                return Json(BadRequest(ModelState));
            }

            Json(await Task.FromResult(this.IContabilista.Update(contabilista)));

            return Json(Ok());
        }

        [HttpPost("/api/ExcluirContabilista")]
        public async Task ExcluirContabilista([FromBody] Contabilista contabilista)
        {
            await Task.FromResult(this.IContabilista.Delete(contabilista));
        }
    }
}
